public interface ITradeCommand
{
    void Execute();
    void Undo();
}
