using System;
using System.Threading.Tasks;
using Messages.Commands;
using NServiceBus;
using NServiceBus.Logging;

namespace ClientUI
{
    class Program
    {
        private const string EndpointName = "ClientUI";

        private static ILog _log = LogManager.GetLogger(EndpointName);

        private static int _nextId = 1;

        private static async Task Main(string[] args)
        {
            Console.Title = EndpointName;
            var endpointConfiguration = new EndpointConfiguration(EndpointName);
            TransportExtensions<LearningTransport> transport = endpointConfiguration.UseTransport<LearningTransport>();
            RoutingSettings<LearningTransport> routing = transport.Routing();
            routing.RouteToEndpoint(typeof(PlaceOrder), "Sales");
            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
            await RunLoop(endpointInstance, 1234);
            await endpointInstance.Stop().ConfigureAwait(false);
        }

        private static async Task RunLoop(IEndpointInstance endpointInstance, int clientId)
        {
            while (true)
            {
                _log.Info("Press 'P' to place an order, or 'Q' to quit.");
                var key = Console.ReadKey();
                //Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.P:
                        var command = new PlaceOrder {CustomerId = clientId, OrderId = NextId};
                        _log.Info($"Sending {command}");
                        await endpointInstance.Send(command).ConfigureAwait(false);
                        break;
                    case ConsoleKey.Q:
                        return;
                    default:
                        _log.Info("Unknown input. Please try again.");
                        break;
                }
            }
        }

        private static int NextId => _nextId++;
    }
}
