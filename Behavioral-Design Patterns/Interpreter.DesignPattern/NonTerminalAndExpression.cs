public class NonTerminalAndExpression(IPermissionExpression right, IPermissionExpression left) : IPermissionExpression
{
    private readonly IPermissionExpression _right = right;
    private readonly IPermissionExpression _left = left;
    public bool Interpret(User user)
    {
        return _right.Interpret(user) && _left.Interpret(user);
    }
}
