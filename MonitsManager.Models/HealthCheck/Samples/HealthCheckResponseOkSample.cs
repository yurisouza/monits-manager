using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitsManager.Models.HealthCheck.Samples
{
    public class HealthCheckResponseOkSample : IExamplesProvider
    {
        public object GetExamples()
        {
            var random = new Random();
            return new HealthCheckResponseOkModel
            {
                Result = new HealthCheckResponseModel
                {
                    HealthCheckKey = Guid.NewGuid(),
                    Name = "Core API",
                    Endpoint = "https://healtcheck.monits.com/",
                    IntervalInMilliseconds = 10000,
                    CreateAt = DateTime.Now.AddDays(-random.Next(1, 10)).AddHours(-random.Next(1, 10)),
                    UpdateAt = DateTime.Now.AddHours(-random.Next(1, 10))
                }
            };
        }
    }
}
