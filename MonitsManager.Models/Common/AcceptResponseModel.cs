using System.Collections.Generic;

namespace MonitsManager.Models.Common
{
    public class AcceptResponseModel : IResponse
    {
        public IList<ErrorModelResponse> Errors { get; set; }

        public int StatusCode()
        {
            return 202;
        }
    }
}
