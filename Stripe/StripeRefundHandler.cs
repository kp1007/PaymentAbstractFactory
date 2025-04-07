public class StripeRefundHandler : IRefundHandler
{
    public void ProcessRefund(string transactionId)
    {
        Console.WriteLine($"[Stripe] Refunding transaction {transactionId}");
    }
}
