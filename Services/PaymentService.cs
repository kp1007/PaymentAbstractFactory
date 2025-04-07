public class PaymentService
{
    private readonly IPaymentGatewayFactory _factory;

    public PaymentService(IPaymentGatewayFactory factory)
    {
        _factory = factory;
    }

    public void MakePayment(decimal amount)
    {
        var processor = _factory.CreatePaymentProcessor();
        processor.ProcessPayment(amount);
    }

    public void RefundPayment(string transactionId)
    {
        var refundHandler = _factory.CreateRefundHandler();
        refundHandler.ProcessRefund(transactionId);
    }

    public void GetPaymentStatus(string transactionId)
    {
        var statusChecker = _factory.CreateStatusChecker();
        statusChecker.CheckStatus(transactionId);
    }
}
