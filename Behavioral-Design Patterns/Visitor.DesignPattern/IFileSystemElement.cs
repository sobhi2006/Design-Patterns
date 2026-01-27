public interface IFileSystemElement
{
    void Accept(IVisitor visitor);
}
