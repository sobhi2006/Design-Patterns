namespace Strategy.DesignPattern;

/// <summary>
/// Strategy Interface - Defines the contract for all payment strategies.
/// This is the core abstraction that enables interchangeable algorithms.
/// </summary>
public interface IPaymentStrategy
{
    /// <summary>
    /// Processes a payment for the given amount.
    /// </summary>
    /// <param name="amount">The amount to be charged</param>
    /// <returns>True if payment was successful, false otherwise</returns>
    bool ProcessPayment(decimal amount);

    /// <summary>
    /// Validates if the payment method is properly configured.
    /// </summary>
    bool Validate();
}
