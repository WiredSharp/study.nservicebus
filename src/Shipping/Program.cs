using System.Threading.Tasks;
using Endpoints;

namespace Shipping
{
    class Program
    {
        private const string EndpointName = "Shipping";

        private static Task Main(string[] args)
        {
            var endpoint = new SimpleEndpoint(EndpointName);
            return endpoint.Run(args);
        }
    }
}
