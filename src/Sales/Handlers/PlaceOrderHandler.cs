using System.Threading.Tasks;
using Messages.Commands;
using Messages.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace Sales.Handlers
{
    internal class PlaceOrderHandler: IHandleMessages<PlaceOrder>
    {
        private static readonly ILog _log = LogManager.GetLogger<PlaceOrderHandler>();

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            _log.Info($"Received {message}");
            return context.Publish(new OrderPlaced {OrderId = message.OrderId});
        }
    }
}