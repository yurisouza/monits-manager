using System.Collections.Generic;

namespace MonitsManager.Models.Common
{
    public class NotFoundResponseModel : IResponse
    {
        public NotFoundResponseModel(string message)
        {
            Errors = new List<ErrorModelResponse>
            {
                new ErrorModelResponse(message)
            };
        }

        public IList<ErrorModelResponse> Errors { get; set; }

        public int StatusCode()
        {
            return 404;
        }
    }
}
