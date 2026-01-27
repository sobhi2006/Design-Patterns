using System.Runtime.InteropServices;

public class Program
{
    public static void Main(string[] args)
    {
        User user = new ()
        {
            UserId = 7,
            Name = "Sob",
            Permissions = ["Write", "Read", "Update"]
        };

        IPermissionExpression read = new TerminalPermission("Read");
        IPermissionExpression write = new TerminalPermission("Write");
        IPermissionExpression delete = new TerminalPermission("Delete");
        IPermissionExpression update = new TerminalPermission("Update");

        IPermissionExpression and = new NonTerminalAndExpression(read, write);
        System.Console.WriteLine(and.Interpret(user));

        IPermissionExpression or = new NonTerminalOrExpression(delete, update);
        System.Console.WriteLine(or.Interpret(user));

        and = new NonTerminalAndExpression(delete, write);
        System.Console.WriteLine(and.Interpret(user));

    }
}