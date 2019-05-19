using System.Threading.Tasks;
using Messages.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace ClientUI.Handlers
{
    internal class OrderShippedHandler: IHandleMessages<OrderShipped>
    {
        private static readonly ILog _log = LogManager.GetLogger<OrderShippedHandler>();

        public Task Handle(OrderShipped message, IMessageHandlerContext context)
        {
            _log.Info("dear customer, your order have been shipped");
            return Task.CompletedTask;
        }
    }
}