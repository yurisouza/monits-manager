using Bogus;
using Swashbuckle.AspNetCore.Examples;
using System;

namespace MonitsManager.Models.User.Samples
{
    public class UserResponseCreatedSample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new UserResponseCreatedModel
            {
                Result = new UserResponseModel
                {
                    UserKey = Guid.NewGuid(),
                    Name = "Tony Stark",
                    Mail = "tonystark@monits.com",
                    Phone = "(DDD)0000-0000",
                    DocumentType = "CPF",
                    DocumentNumber = "00011133388",
                    Password = "***"
                }
            };
        }
    }
}
