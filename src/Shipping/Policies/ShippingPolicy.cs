using System.Threading.Tasks;
using Messages.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace Shipping.Policies
{
    internal class ShippingPolicy : Saga<ShippingPolicy.SagaData>, IAmStartedByMessages<OrderPlaced>, IAmStartedByMessages<OrderBilled>
    {
        internal class SagaData : ContainSagaData
        {
            public int OrderId { get; set; }
            public bool IsOrderPlaced { get; set; }
            public bool IsOrderBilled { get; set; }
        }

        private static readonly ILog _log = LogManager.GetLogger<ShippingPolicy>();

        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            _log.Info($"Received {message}");
            return ProcessOrder(context);
        }

        public Task Handle(OrderBilled message, IMessageHandlerContext context)
        {
            _log.Info($"Received {message}");
            return ProcessOrder(context);
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<SagaData> mapper)
        {
            mapper.ConfigureMapping<OrderPlaced>(msg => msg.OrderId).ToSaga(saga => saga.OrderId);
            mapper.ConfigureMapping<OrderBilled>(msg => msg.OrderId).ToSaga(saga => saga.OrderId);
        }

        private async Task ProcessOrder(IMessageHandlerContext context)
        {
            if (Data.IsOrderPlaced && Data.IsOrderBilled)
            {
                await context.Publish(new OrderShipped { OrderId = Data.OrderId }).ConfigureAwait(false);
                MarkAsComplete();
            }
        }
    }
}