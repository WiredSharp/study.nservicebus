using System.Threading.Tasks;
using Messages.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace Shipping.Handlers
{
    internal class ShipOrderHandler: IHandleMessages<OrderPlaced>, IHandleMessages<OrderBilled>
    {
        private static readonly ILog _log = LogManager.GetLogger<ShipOrderHandler>();

        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            _log.Info($"Received {message}");
            return context.Publish(new OrderShipped { OrderId = message.OrderId });
        }

        public Task Handle(OrderBilled message, IMessageHandlerContext context)
        {
            _log.Info($"Received {message}");
            return context.Publish(new OrderShipped { OrderId = message.OrderId });
        }
    }
}