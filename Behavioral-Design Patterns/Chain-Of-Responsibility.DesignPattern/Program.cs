public class Program
{
    public static void Main(string[] args)
    {
        SupportHandlerChain support1 = new SupportLow();
        SupportHandlerChain support2 = new SupportMed();
        SupportHandlerChain support3 = new SupportHigh();
        support1.SetNext(support2);
        support2.SetNext(support3);

        support1.Handle(new SupportDto("this is my message", Priority.Empty));
    }
}


public class SupportDto
{
    public SupportDto(string message, Priority priority)
    {
        Message = message;
        Priority = priority;
    }

    public string Message { get; set; }
    public Priority Priority { get; set; }
}

public enum Priority
{
    Low,
    Med,
    High,
    Empty
}

public abstract class SupportHandlerChain
{
    protected SupportHandlerChain Next { get; private set; }
    public void SetNext(SupportHandlerChain next)
        => Next = next;

    public abstract void Handle(SupportDto request);
}

public class SupportLow : SupportHandlerChain
{
    public override void Handle(SupportDto request)
    {
        if(request.Priority == Priority.Low)
            System.Console.WriteLine($"{request.Priority} Process Operation with message: {request.Message}......\n");
        else
            Next.Handle(request);
    }
}

public class SupportMed : SupportHandlerChain
{
    public override void Handle(SupportDto request)
    {
        if(request.Priority == Priority.Med)
            System.Console.WriteLine($"{request.Priority} Process Operation with message: {request.Message} ......\n");
        else
            Next.Handle(request);
    }
}


public class SupportHigh : SupportHandlerChain
{
    public override void Handle(SupportDto request)
    {
        if(request.Priority == Priority.High)
            System.Console.WriteLine($"{request.Priority} Process Operation with message: {request.Message} ......\n");
        else
            throw new ArgumentException("Not implement another support to service this operation");
    }
}