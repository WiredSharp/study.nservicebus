using System;
using System.Threading.Tasks;
using NServiceBus;

namespace Endpoints
{
    internal class SimpleEndpoint
    {
        private readonly string EndpointName;

        public SimpleEndpoint(string name)
        {
            EndpointName = name;
        }

        public async Task Run(string[] args)
        {
            Console.Title = EndpointName;
            var endpointConfiguration = new EndpointConfiguration(EndpointName);
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}
