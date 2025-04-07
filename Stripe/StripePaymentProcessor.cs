public class StripePaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"[Stripe] Processing payment of ${amount}");
    }
}
