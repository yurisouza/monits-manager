using Bogus;
using MonitsManager.Models.Common;
using Swashbuckle.AspNetCore.Examples;

namespace MonitsManager.Models.HealthCheck.Samples
{
    public class HealthCheckResponseBadRequestSample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new BadRequestResponse(new string[] { "name", "endpoint", "intervalinmilliseconds" }, "Required:");
        }
    }
}
