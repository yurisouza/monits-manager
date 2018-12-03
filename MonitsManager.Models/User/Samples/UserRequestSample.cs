using Bogus;
using Swashbuckle.AspNetCore.Examples;

namespace MonitsManager.Models.User.Samples
{
    public class UserRequestSample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new UserRequestModel
            {
                Name = "Tony Stark",
                Mail = "tonystark@monits.com",
                Phone = "(DDD)0000-0000",
                DocumentType = "CPF",
                DocumentNumber = "00011133388",
                Password = "123456"
            };
        }
    }
}
