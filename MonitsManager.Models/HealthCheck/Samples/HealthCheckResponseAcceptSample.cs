using Bogus;
using MonitsManager.Models.Common;
using Swashbuckle.AspNetCore.Examples;

namespace MonitsManager.Models.HealthCheck.Samples
{
    public class HealthCheckResponseAcceptSample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new AcceptResponseModel();
        }
    }
}
