using System;
using System.Threading.Tasks;
using Endpoints;

namespace Billing
{
    class Program
    {
        private const string EndpointName = "Billing";

        private static Task Main(string[] args)
        {
            var endpoint = new SimpleEndpoint(EndpointName);
            return endpoint.Run(args);
        }
    }
}
