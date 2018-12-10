using Bogus;
using MonitsManager.Models.Common;
using Swashbuckle.AspNetCore.Examples;

namespace MonitsManager.Models.HealthCheck.Samples
{
    public class HealthCheckResponseForbiddenSample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new ForbiddenResponseModel("Healthcheck already exists.");
        }
    }
}
