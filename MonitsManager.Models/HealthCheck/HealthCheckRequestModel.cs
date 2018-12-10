using MonitsManager.Models.Error;
using System.ComponentModel.DataAnnotations;

namespace MonitsManager.Models.HealthCheck
{
    public class HealthCheckRequestModel
    {
        /// <summary>
        /// Name HealthCheck.
        /// </summary>
        [Required(ErrorMessageResourceName = "NameHealthCheckRequired", ErrorMessageResourceType = typeof(ErrorMessageCatalog))]
        public string Name { get; set; }

        /// <summary>
        /// Endpoint HealthCheck.
        /// </summary>
        [Required(ErrorMessageResourceName = "EndpointHealthCheckRequired", ErrorMessageResourceType = typeof(ErrorMessageCatalog))]
        public string Endpoint { get; set; }

        /// <summary>
        /// Interval in Milliseconds between the requests.
        /// </summary>
        [Required(ErrorMessageResourceName = "IntervalInMillisecondsRequired", ErrorMessageResourceType = typeof(ErrorMessageCatalog))]
        public long IntervalInMilliseconds { get; set; }
    }
}
