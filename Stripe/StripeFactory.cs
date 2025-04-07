
public class StripeFactory : IPaymentGatewayFactory
{
    public IPaymentProcessor CreatePaymentProcessor() => new StripePaymentProcessor();
    public IRefundHandler CreateRefundHandler() => new StripeRefundHandler();
    public IStatusChecker CreateStatusChecker() => new StripeStatusChecker();
}
