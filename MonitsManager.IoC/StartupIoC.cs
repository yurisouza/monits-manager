﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonitsManager.Application.AppServices;
using MonitsManager.Application.Interfaces;
using MonitsManager.Core.Interfaces.Repository;
using MonitsManager.Core.Interfaces.Services;
using MonitsManager.Core.Mapper;
using MonitsManager.Core.RabbitMQ;
using MonitsManager.Core.Repositories;
using MonitsManager.Core.Services;
using MySql.Data.MySqlClient;
using System.Data;

namespace MonitsManager.IoC
{
    public class StartupIoC
    {
        public static void RegisterIoC(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDbConnection>(new MySqlConnection(configuration.GetConnectionString("Database")));
            services.AddSingleton<IQueueService, QueueService>();
            services.AddSingleton<IMapperAdapter, MapperAdapter>();
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IHealthCheckAppService, HealthCheckAppService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IHealthCheckService, HealthCheckService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IHealthCheckRepository, HealthCheckRepository>();
        }
    }
}
