using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Events
{
    internal class OrderPlaced: IEvent
    {
        public int OrderId { get; set; }

        public override string ToString()
        {
            return $"Order #{OrderId} placed";
        }
    }
}
