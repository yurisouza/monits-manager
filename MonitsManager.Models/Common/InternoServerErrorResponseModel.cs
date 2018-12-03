using System.Collections.Generic;

namespace MonitsManager.Models.Common
{
    public class InternoServerErrorResponseModel : IResponse
    {
        public InternoServerErrorResponseModel(string message)
        {
            Errors = new List<ErrorModelResponse>
            {
                new ErrorModelResponse(message)
            };
        }

        public IList<ErrorModelResponse> Errors { get; set; }

        public int StatusCode()
        {
            return 500;
        }
    }
}
