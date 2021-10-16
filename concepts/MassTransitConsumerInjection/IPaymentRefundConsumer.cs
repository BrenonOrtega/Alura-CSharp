using MassTransit;

namespace MassTransitConsumerInjection
{
    public interface IPaymentRefundConsumer : IConsumer<PaymentRefund>
    {
    }
}