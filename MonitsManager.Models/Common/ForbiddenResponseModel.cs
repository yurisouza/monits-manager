using System.Collections.Generic;

namespace MonitsManager.Models.Common
{
    public class ForbiddenResponseModel : IResponse
    {
        public ForbiddenResponseModel(string message)
        {
            Errors = new List<ErrorModelResponse>
            {
                new ErrorModelResponse(message)
            };
        }

        public IList<ErrorModelResponse> Errors { get; set; }

        public int StatusCode()
        {
            return 403;
        }
    }
}
