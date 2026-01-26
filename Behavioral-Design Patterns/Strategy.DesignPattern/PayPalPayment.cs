namespace Strategy.DesignPattern;

/// <summary>
/// Concrete Strategy - PayPal Payment Implementation.
/// Encapsulates the PayPal payment algorithm.
/// </summary>
public class PayPalPayment : IPaymentStrategy
{
    private readonly string _email;
    private readonly string _password;

    public PayPalPayment(string email, string password)
    {
        _email = email;
        _password = password;
    }

    public bool Validate()
    {
        // Simulate PayPal account validation
        if (string.IsNullOrWhiteSpace(_email) || !_email.Contains('@'))
        {
            Console.WriteLine("❌ Invalid PayPal email.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(_password))
        {
            Console.WriteLine("❌ Invalid PayPal password.");
            return false;
        }

        Console.WriteLine("✅ PayPal account authenticated successfully.");
        return true;
    }

    public bool ProcessPayment(decimal amount)
    {
        if (!Validate()) return false;

        Console.WriteLine($"🅿️  Processing PayPal Payment...");
        Console.WriteLine($"   Account: {_email}");
        Console.WriteLine($"   Amount: ${amount:F2}");
        Console.WriteLine($"✅ Payment of ${amount:F2} processed successfully via PayPal!");

        return true;
    }
}
