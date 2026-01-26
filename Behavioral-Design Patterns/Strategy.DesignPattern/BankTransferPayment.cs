namespace Strategy.DesignPattern;

/// <summary>
/// Concrete Strategy - Bank Transfer Payment Implementation.
/// Encapsulates the bank transfer payment algorithm.
/// </summary>
public class BankTransferPayment(string accountNumber, string routingNumber, string accountHolderName) : IPaymentStrategy
{
    private readonly string _accountNumber = accountNumber;
    private readonly string _routingNumber = routingNumber;
    private readonly string _accountHolderName = accountHolderName;

    public bool Validate()
    {
        // Simulate bank account validation
        if (string.IsNullOrWhiteSpace(_accountNumber) || _accountNumber.Length < 8)
        {
            Console.WriteLine("❌ Invalid bank account number.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(_routingNumber) || _routingNumber.Length != 9)
        {
            Console.WriteLine("❌ Invalid routing number.");
            return false;
        }

        Console.WriteLine("✅ Bank account validated successfully.");
        return true;
    }

    public bool ProcessPayment(decimal amount)
    {
        if (!Validate()) return false;

        var maskedAccount = $"****{_accountNumber[^4..]}";

        Console.WriteLine($"🏦 Processing Bank Transfer Payment...");
        Console.WriteLine($"   Account: {maskedAccount}");
        Console.WriteLine($"   Holder: {_accountHolderName}");
        Console.WriteLine($"   Routing: {_routingNumber}");
        Console.WriteLine($"   Amount: ${amount:F2}");
        Console.WriteLine($"✅ Payment of ${amount:F2} processed successfully via Bank Transfer!");

        return true;
    }
}
