using System;
using System.Collections.Generic;
using System.Text;

namespace MonitsManager.Core.Mapper
{
    public class MapperAdapter : IMapperAdapter
    {
        public TDestination Map<TSource, TDestination>(TSource obj)
        {
            return AutoMapper.Mapper.Map<TSource, TDestination>(obj);
        }
    }
}
