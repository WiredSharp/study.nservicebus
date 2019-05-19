using NServiceBus;

namespace Messages.Commands
{
    internal class PlaceOrder: ICommand
    {
        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public override string ToString()
        {
            return $"PlaceOrder #{OrderId} for Customer #{CustomerId}";
        }
    }
}
