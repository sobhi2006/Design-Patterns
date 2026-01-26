public class Program
{
    public static void Main(string[] args)
    {
        var account = new BankAccount(1000);

        System.Console.WriteLine("--- Active Account ---");
        account.Deposit(500);
        account.Withdraw(200);

        System.Console.WriteLine("--- Freezing Account ---");
        account.State = new FrozenAccount(account);
        account.Withdraw(100);
        account.Deposit(300);

        System.Console.WriteLine("--- Closing Account ---");
        account.State = new ClosedAccount(account);
        account.Withdraw(50);
        account.Deposit(150);
    }
}

public interface IAccountState
{
    public void Withdraw(decimal amount);
    public void Deposit(decimal amount);
}

public class BankAccount : IAccountState
{
    public decimal Balance { get; set; }
    public IAccountState State { get; set; }

    public BankAccount(decimal balance)
    {
        this.Balance = balance;
        State = new ActiveAccount(this);
    }

    public void Withdraw(decimal amount)
    {
        State.Withdraw(amount);
    }

    public void Deposit(decimal amount)
    {
        State.Deposit(amount);
    }
}

public class ActiveAccount(BankAccount bankAccount) : IAccountState
{
    private readonly BankAccount _bankAccount = bankAccount;

    public void Deposit(decimal amount)
    {
        _bankAccount.Balance += amount;
        System.Console.WriteLine($"Deposit {amount}, balance is {_bankAccount.Balance}");
    }

    public void Withdraw(decimal amount)
    {
        _bankAccount.Balance -= amount;
        System.Console.WriteLine($"Withdraw {amount}, balance is {_bankAccount.Balance}");
    }
}

public class FrozenAccount(BankAccount bankAccount) : IAccountState
{
    private readonly BankAccount _bankAccount = bankAccount;

    public void Deposit(decimal amount)
    {
        _bankAccount.Balance += amount;
        System.Console.WriteLine($"Deposit {amount}, balance is {_bankAccount.Balance}");
    }

    public void Withdraw(decimal amount)
    {
        System.Console.WriteLine($"Withdraw can'nt be apply because it is frozen account, balance is {_bankAccount.Balance}");
    }
}

public class ClosedAccount(BankAccount bankAccount) : IAccountState
{
    private readonly BankAccount _bankAccount = bankAccount;

    public void Deposit(decimal amount)
    {
        System.Console.WriteLine($"Deposit can'nt be apply because it is closed account, balance is {_bankAccount.Balance}");
    }

    public void Withdraw(decimal amount)
    {
        System.Console.WriteLine($"Withdraw can'nt be apply because it is closed account, balance is {_bankAccount.Balance}");
    }
}