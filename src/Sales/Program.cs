using System.Threading.Tasks;
using Endpoints;

namespace Sales
{
    class Program
    {
        private const string EndpointName = "Sales";

        private static Task Main(string[] args)
        {
            var endpoint = new SimpleEndpoint(EndpointName);
            return endpoint.Run(args);
        }
    }
}
