public class TerminalPermission(string permission) : IPermissionExpression
{
    private readonly string _permissionName = permission;

    public bool Interpret(User user)
    {
        return user.Permissions.Any(p => p == _permissionName);
    }
}
