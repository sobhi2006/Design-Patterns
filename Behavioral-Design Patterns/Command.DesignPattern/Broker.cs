public class Broker
{
    private readonly Stack<ITradeCommand> _commandHistory = new();

    public void TakeOrder(ITradeCommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void UndoLastOrder()
    {
        if (_commandHistory.Any())
            _commandHistory.Pop().Undo();
    }
}