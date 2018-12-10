using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitsManager.Models.HealthCheck.Samples
{
    public class HealthCheckRequestSample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new HealthCheckRequestModel
            {
                Name = "Core API",
                Endpoint = "https://healtcheck.monits.com/",
                IntervalInMilliseconds = 10000
            };
        }
    }
}
