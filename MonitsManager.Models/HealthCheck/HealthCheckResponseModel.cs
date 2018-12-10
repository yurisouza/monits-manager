using Newtonsoft.Json;
using System;

namespace MonitsManager.Models.HealthCheck
{
    public class HealthCheckResponseModel
    {
        /// <summary>
        /// HealthCheckKey.
        /// </summary>
        [JsonProperty("healthcheck_key")]
        public Guid HealthCheckKey { get; set; }

        /// <summary>
        /// Name HealthCheck.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Endpoint HealthCheck.
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Interval in Milliseconds between the requests.
        /// </summary>
        public long IntervalInMilliseconds { get; set; }

        /// <summary>
        /// CreateAt.
        /// </summary>
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// UpdateAt.
        /// </summary>
        public DateTime UpdateAt { get; set; }
    }
}
