using Bogus;
using MonitsManager.Models.Common;
using Swashbuckle.AspNetCore.Examples;

namespace MonitsManager.Models.User.Samples
{
    public class UserResponseBadRequestSample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new BadRequestResponse(new string[] { "name", "mail", "document_number", "document_type", "password" }, "Required:");
        }
    }
}
