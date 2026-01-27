public class File : IFileSystemElement
{
    public string Name { get; }
    public long Size { get; }

    public File(string name, long size)
    {
        Name = name;
        Size = size;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
