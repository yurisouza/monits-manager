using MonitsManager.Application.Interfaces;
using MonitsManager.Core.Interfaces.Services;
using MonitsManager.Core.Mapper;
using MonitsManager.Domain;
using MonitsManager.Models.Common;
using MonitsManager.Models.Exceptions;
using MonitsManager.Models.HealthCheck;
using System;

namespace MonitsManager.Application.AppServices
{
    public class HealthCheckAppService : IHealthCheckAppService
    {
        private readonly IHealthCheckService _healthCheckService;
        private readonly IMapperAdapter _mapperAdapter;

        public HealthCheckAppService(IHealthCheckService healthCheckService, IMapperAdapter mapperAdapter)
        {
            _healthCheckService = healthCheckService;
            _mapperAdapter = mapperAdapter;
        }

        public IResponse Delete(Guid key)
        {
            try
            {
                _healthCheckService.Delete(key);
                return new AcceptResponseModel();
            }
            catch (NotFoundException ex)
            {
                return new NotFoundResponseModel(ex.Message);
            }
            catch (InternalServerErrorException ex)
            {
                return new InternoServerErrorResponseModel(ex.Message);
            }
        }

        public IResponse Get(Guid key)
        {
            try
            {
                var healthCheck = _healthCheckService.Get(key);
                return _mapperAdapter.Map<HealthCheck, HealthCheckResponseCreatedModel>(healthCheck);
            }
            catch (NotFoundException ex)
            {
                return new NotFoundResponseModel(ex.Message);
            }
        }

        public IResponse Insert(HealthCheckRequestModel entity)
        {
            try
            {
                var healthCheck = _mapperAdapter.Map<HealthCheckRequestModel, HealthCheck>(entity);
                healthCheck = _healthCheckService.Insert(healthCheck);
                return _mapperAdapter.Map<HealthCheck, HealthCheckResponseCreatedModel>(healthCheck);
            }
            catch (ForbbidenException ex)
            {
                return new ForbiddenResponseModel(ex.Message);
            }
            catch (InternalServerErrorException ex)
            {
                return new InternoServerErrorResponseModel(ex.Message);
            }
        }

        public IResponse Update(Guid key, HealthCheckRequestModel entity)
        {
            try
            {
                var healthCheck = _mapperAdapter.Map<HealthCheckRequestModel, HealthCheck>(entity);
                healthCheck.HealthCheckKey = key;
                healthCheck = _healthCheckService.Update(healthCheck);
                return _mapperAdapter.Map<HealthCheck, HealthCheckResponseOkModel>(healthCheck);
            }
            catch (NotFoundException ex)
            {
                return new NotFoundResponseModel(ex.Message);
            }
            catch (ForbbidenException ex)
            {
                return new ForbiddenResponseModel(ex.Message);
            }
            catch (InternalServerErrorException ex)
            {
                return new InternoServerErrorResponseModel(ex.Message);
            }
        }
    }
}
