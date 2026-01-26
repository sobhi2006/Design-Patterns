namespace Strategy.DesignPattern;

/// <summary>
/// Concrete Strategy - Cryptocurrency Payment Implementation.
/// Encapsulates the crypto payment algorithm.
/// </summary>
public class CryptoPayment(string walletAddress, string cryptoType = "Bitcoin") : IPaymentStrategy
{
    private readonly string _walletAddress = walletAddress;
    private readonly string _cryptoType = cryptoType;

    public bool Validate()
    {
        // Simulate wallet address validation
        if (string.IsNullOrWhiteSpace(_walletAddress) || _walletAddress.Length < 26)
        {
            Console.WriteLine("❌ Invalid crypto wallet address.");
            return false;
        }

        Console.WriteLine($"✅ {_cryptoType} wallet validated successfully.");
        return true;
    }

    public bool ProcessPayment(decimal amount)
    {
        if (!Validate()) return false;

        var shortWallet = $"{_walletAddress[..6]}...{_walletAddress[^4..]}";

        Console.WriteLine($"🪙 Processing {_cryptoType} Payment...");
        Console.WriteLine($"   Wallet: {shortWallet}");
        Console.WriteLine($"   Amount: ${amount:F2} (≈ {amount / 45000m:F6} BTC)");
        Console.WriteLine($"✅ Payment of ${amount:F2} processed successfully via {_cryptoType}!");

        return true;
    }
}
