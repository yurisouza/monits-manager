using Bogus;
using MonitsManager.Models.Common;
using Swashbuckle.AspNetCore.Examples;

namespace MonitsManager.Models.User.Samples
{
    public class UserResponseForbiddenSample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new ForbiddenResponseModel("User already exists. Mail or document number already registered");
        }
    }
}
