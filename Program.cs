using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Payment Processing System ===");
        Console.WriteLine("Select a Payment Gateway:");
        Console.WriteLine("1. Stripe");
        Console.WriteLine("2. PayPal");
        Console.WriteLine("3. Square");

        string gatewayChoice = Console.ReadLine();
        IPaymentGatewayFactory factory = gatewayChoice switch
        {
            "1" => new StripeFactory(),
            //"2" => new PayPalFactory(),
            //"3" => new SquareFactory(),
            _ => throw new Exception("Invalid gateway selection.")
        };

        var service = new PaymentService(factory);

        Console.WriteLine("\nChoose an operation:");
        Console.WriteLine("1. Make Payment");
        Console.WriteLine("2. Refund Payment");
        Console.WriteLine("3. Check Status");

        string actionChoice = Console.ReadLine();

        switch (actionChoice)
        {
            case "1":
                Console.Write("Enter amount to pay: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    service.MakePayment(amount);
                }
                else
                {
                    Console.WriteLine("Invalid amount.");
                }
                break;

            case "2":
                Console.Write("Enter transaction ID to refund: ");
                string refundId = Console.ReadLine();
                service.RefundPayment(refundId);
                break;

            case "3":
                Console.Write("Enter transaction ID to check status: ");
                string statusId = Console.ReadLine();
                service.GetPaymentStatus(statusId);
                break;

            default:
                Console.WriteLine("Invalid operation.");
                break;
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
