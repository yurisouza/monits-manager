using System.Collections.Generic;

namespace MonitsManager.Models.Common
{
    public interface IResponse<T> : IResponse where T : class
    {
        T Result { get; set; }
    }

    public interface IResponse
    {
        IList<ErrorModelResponse> Errors { get; set; }
        int StatusCode();
    }
}
