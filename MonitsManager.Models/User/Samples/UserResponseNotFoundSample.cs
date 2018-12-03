using Bogus;
using MonitsManager.Models.Common;
using Swashbuckle.AspNetCore.Examples;

namespace MonitsManager.Models.User.Samples
{
    public class UserResponseNotFoundSample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new NotFoundResponseModel("User not found");
        }
    }
}
