using System;
using System.Collections.Generic;
using System.Text;

namespace MonitsManager.Core.Mapper
{
    public interface IMapperAdapter
    {
        TDestination Map<TSource, TDestination>(TSource obj);
    }
}
