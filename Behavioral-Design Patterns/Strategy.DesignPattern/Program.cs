using Strategy.DesignPattern;

/*
* ╔═══════════════════════════════════════════════════════════════════════════════╗
* ║                        STRATEGY DESIGN PATTERN                                ║
* ║                     Payment Processing Example                                ║
* ╠═══════════════════════════════════════════════════════════════════════════════╣
* ║                                                                               ║
* ║  DEFINITION:                                                                  ║
* ║  The Strategy Pattern defines a family of algorithms, encapsulates each one,  ║
* ║  and makes them interchangeable. It lets the algorithm vary independently     ║
* ║  from clients that use it.                                                    ║
* ║                                                                               ║
* ║  COMPONENTS:                                                                  ║
* ║  ┌─────────────────────────────────────────────────────────────────────────┐  ║
* ║  │  1. Strategy (IPaymentStrategy)                                         │  ║
* ║  │     → Interface declaring the algorithm signature                       │  ║
* ║  │                                                                         │  ║
* ║  │  2. Concrete Strategies                                                 │  ║
* ║  │     → CreditCardPayment, PayPalPayment, CryptoPayment, BankTransfer     │  ║
* ║  │     → Each implements the algorithm differently                         │  ║
* ║  │                                                                         │  ║
* ║  │  3. Context (ShoppingCart)                                              │  ║
* ║  │     → Maintains reference to a Strategy object                          │  ║
* ║  │     → Delegates work to the Strategy                                    │  ║
* ║  └─────────────────────────────────────────────────────────────────────────┘  ║
* ║                                                                               ║
* ║  BENEFITS:                                                                    ║
* ║  ✓ Open/Closed Principle - Add new strategies without modifying context       ║
* ║  ✓ Single Responsibility - Each strategy handles one algorithm                ║
* ║  ✓ Runtime Flexibility - Switch algorithms at runtime                         ║
* ║  ✓ Eliminates Conditionals - No if/else or switch for algorithm selection     ║
* ║  ✓ Easy Testing - Strategies can be tested independently                      ║
* ║                                                                               ║
* ║  WHEN TO USE:                                                                 ║
* ║  • Multiple algorithms for a specific task                                    ║
* ║  • Need to switch algorithms at runtime                                       ║
* ║  • Want to isolate algorithm implementation from using code                   ║
* ║  • Class has multiple conditional behaviors                                   ║
* ║                                                                               ║
* ╚═══════════════════════════════════════════════════════════════════════════════╝
 */

Console.WriteLine("╔═══════════════════════════════════════════════════════════════╗");
Console.WriteLine("║         STRATEGY PATTERN - Payment Processing Demo            ║");
Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝\n");

// Create the Context (ShoppingCart)
var cart = new ShoppingCart();

// Add items to the cart
cart.AddItem("MacBook Pro 16\"", 2499.00m);
cart.AddItem("Magic Mouse", 99.00m);
cart.AddItem("USB-C Hub", 79.99m, 2);

Console.WriteLine("\n" + new string('═', 60));
Console.WriteLine("  DEMO 1: Credit Card Payment Strategy");
Console.WriteLine(new string('═', 60) + "\n");

// Set Credit Card as the payment strategy
var creditCardStrategy = new CreditCardPayment(
    cardNumber: "4532015112830366",
    cardHolderName: "John Doe",
    cvv: "123",
    expiryDate: "12/26"
);
cart.SetPaymentStrategy(creditCardStrategy);
cart.Checkout();

// Add new items for next demo
Console.WriteLine("\n" + new string('═', 60));
Console.WriteLine("  DEMO 2: PayPal Payment Strategy");
Console.WriteLine(new string('═', 60) + "\n");

cart.AddItem("iPhone 15 Pro", 1199.00m);
cart.AddItem("AirPods Pro", 249.00m);

// Switch to PayPal strategy at runtime - KEY FEATURE!
var paypalStrategy = new PayPalPayment(
    email: "john.doe@email.com",
    password: "securePassword123"
);
cart.SetPaymentStrategy(paypalStrategy);
cart.Checkout();

// Demonstrate Cryptocurrency payment
Console.WriteLine("\n" + new string('═', 60));
Console.WriteLine("  DEMO 3: Cryptocurrency Payment Strategy");
Console.WriteLine(new string('═', 60) + "\n");

cart.AddItem("Tesla Model S", 89990.00m);

var cryptoStrategy = new CryptoPayment(
    walletAddress: "bc1qxy2kgdygjrsqtzq2n0yrf2493p83kkfjhx0wlh",
    cryptoType: "Bitcoin"
);
cart.SetPaymentStrategy(cryptoStrategy);
cart.Checkout();

// Demonstrate Bank Transfer payment
Console.WriteLine("\n" + new string('═', 60));
Console.WriteLine("  DEMO 4: Bank Transfer Payment Strategy");
Console.WriteLine(new string('═', 60) + "\n");

cart.AddItem("Enterprise Software License", 15000.00m);
cart.AddItem("Annual Support Package", 3000.00m);

var bankTransferStrategy = new BankTransferPayment(
    accountNumber: "1234567890",
    routingNumber: "021000021",
    accountHolderName: "Acme Corporation"
);
cart.SetPaymentStrategy(bankTransferStrategy);
cart.Checkout();

// Summary
Console.WriteLine("\n" + new string('═', 60));
Console.WriteLine("                    KEY TAKEAWAYS");
Console.WriteLine(new string('═', 60));
Console.WriteLine(@"
  📌 The ShoppingCart (Context) doesn't know HOW payments work
  📌 Each Payment Strategy encapsulates its own algorithm
  📌 We can switch payment methods at runtime seamlessly
  📌 Adding new payment methods (Apple Pay, Google Pay, etc.)
     requires NO changes to the ShoppingCart class
  📌 Each strategy can be tested independently

  This is the power of the Strategy Pattern! 🚀
");
