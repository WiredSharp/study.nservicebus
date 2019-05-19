using System.Threading.Tasks;
using Messages.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace Billing.Handlers
{
    internal class BillOrderHandler: IHandleMessages<OrderPlaced>
    {
        private static readonly ILog _log = LogManager.GetLogger<BillOrderHandler>();

        public Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            _log.Info($"Received {message}");
            return context.Publish(new OrderBilled { OrderId = message.OrderId });
        }
    }
}