using MonitsManager.Models.Common;
using MonitsManager.Models.HealthCheck;

namespace MonitsManager.Application.Interfaces
{
    public interface IHealthCheckAppService : IAppServiceBase<HealthCheckRequestModel, IResponse>
    {
    }
}
