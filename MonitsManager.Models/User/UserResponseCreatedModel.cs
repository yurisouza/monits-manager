using MonitsManager.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitsManager.Models.User
{
    public class UserResponseCreatedModel : IResponse<UserResponseModel>
    {
        public UserResponseCreatedModel() { }
        public UserResponseCreatedModel(string messageFail)
        {
            Errors = new List<ErrorModelResponse>
            {
                new ErrorModelResponse(messageFail)
            };
        }

        public UserResponseModel Result { get; set; }
        public IList<ErrorModelResponse> Errors { get; set; }

        public int StatusCode()
        {
            return 201;
        }
    }
}
