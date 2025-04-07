public class StripeStatusChecker : IStatusChecker
{
    public void CheckStatus(string transactionId)
    {
        Console.WriteLine($"[Stripe] Checking status of transaction {transactionId}");
    }
}
