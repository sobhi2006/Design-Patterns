public class Folder(string name) : IFileSystemElement
{
    public string Name { get; } = name;
    public List<IFileSystemElement> Elements { get; } = new();

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
