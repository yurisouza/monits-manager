using MonitsManager.Core.Interfaces.Repository;
using MonitsManager.Core.Interfaces.Services;
using MonitsManager.Core.RabbitMQ;
using MonitsManager.Domain;
using MonitsManager.Models.Exceptions;
using System;

namespace MonitsManager.Core.Services
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly IHealthCheckRepository _healthCheckRepository;
        private readonly IQueueService _queueService;

        public HealthCheckService(IHealthCheckRepository healthCheckRepository, IQueueService queueService)
        {
            _healthCheckRepository = healthCheckRepository;
            _queueService = queueService;
        }

        public bool Delete(Guid key)
        {
            if (Get(key) == null)
                throw new NotFoundException("HealthCheck not found");

            try
            {
                return _healthCheckRepository.Delete(key);
            }
            catch (Exception)
            {
                throw new InternalServerErrorException("Not possible delete the healthCheck");
            }
        }

        public HealthCheck Get(Guid key)
        {
            var healthCheck = _healthCheckRepository.Get(key);

            if (healthCheck == null)
                throw new NotFoundException("HealthCheck not found");

            return healthCheck;
        }

        public HealthCheck Insert(HealthCheck entity)
        {
            try
            {
                entity.HealthCheckKey = Guid.NewGuid();
                entity.CreateAt = DateTime.UtcNow;
                entity.UpdateAt = entity.CreateAt;

                var response = _healthCheckRepository.Insert(entity);

                _queueService.Send(response, "HealthCheck");
                return response;
            }
            catch (Exception ex)
            {
                throw new InternalServerErrorException("Not was possible insert the healthCheck");
            }

            throw new ForbbidenException("HealthCheck already exists");
        }

        public HealthCheck Update(HealthCheck entity)
        {
            var healthCheck = Get(entity.HealthCheckKey);

            try
            {
                entity.UpdateAt = DateTime.UtcNow;
                _queueService.Send(entity, "HealthCheck");
                return _healthCheckRepository.Update(entity);
            }
            catch (Exception)
            {
                throw new InternalServerErrorException("Not was possible update the healthCheck");
            }
        }
    }
}
