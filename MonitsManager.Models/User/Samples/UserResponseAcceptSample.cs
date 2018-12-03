using Bogus;
using MonitsManager.Models.Common;
using Swashbuckle.AspNetCore.Examples;

namespace MonitsManager.Models.User.Samples
{
    public class UserResponseAcceptSample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new AcceptResponseModel();
        }
    }
}
