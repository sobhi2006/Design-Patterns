namespace Strategy.DesignPattern;

/// <summary>
/// Concrete Strategy - Credit Card Payment Implementation.
/// Encapsulates the credit card payment algorithm.
/// </summary>
public class CreditCardPayment(string cardNumber, string cardHolderName, string cvv, string expiryDate) : IPaymentStrategy
{
    private readonly string _cardNumber = cardNumber;
    private readonly string _cardHolderName = cardHolderName;
    private readonly string _cvv = cvv;
    private readonly string _expiryDate = expiryDate;

    public bool Validate()
    {
        // Simulate credit card validation
        if (string.IsNullOrWhiteSpace(_cardNumber) || _cardNumber.Length < 16)
        {
            Console.WriteLine("❌ Invalid card number.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(_cvv) || _cvv.Length != 3)
        {
            Console.WriteLine("❌ Invalid CVV.");
            return false;
        }

        Console.WriteLine("✅ Credit card validated successfully.");
        return true;
    }

    public bool ProcessPayment(decimal amount)
    {
        if (!Validate()) return false;

        // Mask card number for security
        var maskedCard = $"****-****-****-{_cardNumber[^4..]}";

        Console.WriteLine($"💳 Processing Credit Card Payment...");
        Console.WriteLine($"   Card: {maskedCard}");
        Console.WriteLine($"   Holder: {_cardHolderName}");
        Console.WriteLine($"   Amount: ${amount:F2}");
        Console.WriteLine($"✅ Payment of ${amount:F2} processed successfully via Credit Card!");

        return true;
    }
}
