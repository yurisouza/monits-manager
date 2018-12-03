using MonitsManager.Models.Common;
using MonitsManager.Models.User;

namespace MonitsManager.Application.Interfaces
{
    public interface IUserAppService : IAppServiceBase<UserRequestModel, IResponse>
    {
    }
}
