using AutoMapper;
using MonitsManager.Domain;
using MonitsManager.Models.HealthCheck;
using MonitsManager.Models.User;

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
            config.CreateMap<HealthCheckRequestModel, HealthCheck>();
        }

        private static void MapperResponse(IMapperConfigurationExpression config)
        {
            config.CreateMap<User, UserResponseCreatedModel>()
                    .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src));
            config.CreateMap<User, UserResponseOkModel>()
                    .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src));
            config.CreateMap<User, UserResponseModel>();
            config.CreateMap<HealthCheck, HealthCheckResponseCreatedModel>()
        .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src));
            config.CreateMap<HealthCheck, HealthCheckResponseOkModel>()
                    .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src));
            config.CreateMap<HealthCheck, HealthCheckResponseModel>();
        }
    }
}
