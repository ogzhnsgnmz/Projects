using MassTransit;
using Shared.Events;

namespace PaymentAPI.Consumers
{
    public class StockReservedEventConsumer : IConsumer<StockReservedEvent>
    {
        readonly IPublishEndpoint _publishEndpoint;

        public StockReservedEventConsumer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public Task Consume(ConsumeContext<StockReservedEvent> context)
        {
            if(true)
            {
                PaymentComplatedEvent paymentComplatedEvent = new()
                {
                    OrderId = context.Message.OrderId
                };
                _publishEndpoint.Publish(paymentComplatedEvent);

                Console.WriteLine("Ödeme başarılı...");
            }
            else
            {
                PaymentFailedEvent paymentFailedEvent = new()
                {
                    OrderId = context.Message.OrderId,
                    Message = "Bakiye yetersiz"
                };

                _publishEndpoint.Publish(paymentFailedEvent);

                Console.WriteLine("Ödeme başarısız...");
            }
            return Task.CompletedTask;
        }
    }
}
