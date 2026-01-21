public class Program
{
    public static void Main(string[] args)
    {
        IRenderer jsonRender = new JsonRenderer();
        IRenderer consoleRender = new ConsoleRenderer();

        var errorLog = new ErrorLogger(jsonRender);
        errorLog.RenderProcess("this is my log as error and in json format");

        errorLog = new ErrorLogger(consoleRender);
        errorLog.RenderProcess("this is my log as error and console format");

        var auditLog = new AuditLogger(consoleRender);
        auditLog.RenderProcess("this is my log as audit and console format");
    }
}
