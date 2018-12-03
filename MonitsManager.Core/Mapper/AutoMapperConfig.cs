using AutoMapper;
using MonitsManager.Domain;
using MonitsManager.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonitsManager.Core.Mapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                MapperRequest(config);
                MapperResponse(config);
            });
        }

        private static void MapperRequest(IMapperConfigurationExpression config)
        {
            config.CreateMap<UserRequestModel, User>();
        }

        private static void MapperResponse(IMapperConfigurationExpression config)
        {
            config.CreateMap<User, UserResponseCreatedModel>()
                    .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src));
            config.CreateMap<User, UserResponseModel>();
        }
    }
}
