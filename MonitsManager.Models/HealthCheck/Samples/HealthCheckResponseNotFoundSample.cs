using MonitsManager.Models.Common;
using Swashbuckle.AspNetCore.Examples;

namespace MonitsManager.Models.HealthCheck.Samples
{
    public class HealthCheckResponseNotFoundSample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new NotFoundResponseModel("HealthCheck not found");
        }
    }
}
