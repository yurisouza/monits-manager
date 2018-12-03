using System.Collections.Generic;

namespace MonitsManager.Models.Common
{
    public class BadRequestResponse : IResponse
    {
        public BadRequestResponse(string message)
        {
            Errors = new List<ErrorModelResponse>
            {
                new ErrorModelResponse(message)
            };
        }

        public BadRequestResponse(IList<string> messages, string messageInitConcat = "")
        {
            Errors = new List<ErrorModelResponse>();

            foreach (var message in messages)
            {
                Errors.Add(new ErrorModelResponse($"{messageInitConcat} {message}".Trim()));
            }
        }

        public IList<ErrorModelResponse> Errors { get; set; }

        public int StatusCode()
        {
            return 400;
        }
    }
}
