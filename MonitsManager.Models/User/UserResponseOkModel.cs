using MonitsManager.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitsManager.Models.User
{
    public class UserResponseOkModel : IResponse<UserResponseModel>
    {
        public UserResponseOkModel() { }
        public UserResponseOkModel(string messageFail)
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
            return 200;
        }
    }
}
