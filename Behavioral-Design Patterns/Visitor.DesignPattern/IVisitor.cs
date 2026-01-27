public interface IVisitor
{
    void Visit(File file);
    void Visit(Folder directory);    
}
