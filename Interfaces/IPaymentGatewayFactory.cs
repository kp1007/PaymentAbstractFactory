public interface IPaymentGatewayFactory
{
    IPaymentProcessor CreatePaymentProcessor();
    IRefundHandler CreateRefundHandler();
    IStatusChecker CreateStatusChecker();
}
