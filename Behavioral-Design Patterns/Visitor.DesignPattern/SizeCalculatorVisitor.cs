public class SizeCalculatorVisitor : IVisitor
{
    public long TotalSize { get; private set; } = 0;

    public void Visit(File file)
    {
        TotalSize += file.Size;
    }

    public void Visit(Folder directory)
    {
        foreach (var element in directory.Elements)
        {
            element.Accept(this);
        }
    }
}