using MonitsManager.Models.Common;
using System.Collections.Generic;

namespace MonitsManager.Models.HealthCheck
{
    public class HealthCheckResponseCreatedModel : IResponse<HealthCheckResponseModel>
    {
        public HealthCheckResponseCreatedModel() { }
        public HealthCheckResponseCreatedModel(string messageFail)
        {
            Errors = new List<ErrorModelResponse>
            {
                new ErrorModelResponse(messageFail)
            };
        }

        public HealthCheckResponseModel Result { get; set; }
        public IList<ErrorModelResponse> Errors { get; set; }

        public int StatusCode()
        {
            return 201;
        }
    }
}
