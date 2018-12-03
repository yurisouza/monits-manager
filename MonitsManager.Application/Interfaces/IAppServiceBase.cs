using System;
using System.Collections.Generic;
using System.Text;

namespace MonitsManager.Application.Interfaces
{
    public interface IAppServiceBase<TRequest, TResponse>
    {
        TResponse Get(Guid key);
        TResponse Insert(TRequest entity);
        TResponse Update(Guid key, TRequest entity);
        TResponse Delete(Guid key);
    }
}
