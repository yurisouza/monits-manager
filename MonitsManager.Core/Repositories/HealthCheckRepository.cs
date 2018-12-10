using Dapper;
using MonitsManager.Core.Interfaces.Repository;
using MonitsManager.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MonitsManager.Core.Repositories
{
    public class HealthCheckRepository : RepositoryBase<HealthCheck>, IHealthCheckRepository
    {
        public HealthCheckRepository(IDbConnection connection) : base(connection){}

        public override bool Delete(Guid key)
        {
            try
            {
                _connection.Open();
                return _connection.Execute("DELETE FROM HealthCheck WHERE HealthCheckKey = @HealthCheckKey", new { HealthCheckKey = key }) > 0;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                _connection.Close();
            }
        }

        public override HealthCheck Get(Guid key)
        {
            try
            {
                _connection.Open();
                return _connection.QueryFirstOrDefault<HealthCheck>("SELECT * FROM HealthCheck WHERE HealthCheckKey = @HealthCheckKey LIMIT 1", new { HealthCheckKey = key });
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                _connection.Close();
            }
        }

        public override HealthCheck Insert(HealthCheck entity)
        {
            try
            {
                _connection.Open();
                _connection.Execute("INSERT INTO HealthCheck (HealthCheckKey, Name, Endpoint, IntervalInMilliseconds, CreateAt, UpdateAt) VALUES (@HealthCheckKey, @Name, @Endpoint, @IntervalInMilliseconds, @CreateAt, @UpdateAt)", entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public override HealthCheck Update(HealthCheck entity)
        {
            try
            {
                _connection.Open();
                _connection.Execute("UPDATE HealthCheck SET Name = @Name, Endpoint = @Endpoint, IntervalInMilliseconds = @IntervalInMilliseconds, CreateAt = @CreateAt, UpdateAt = @UpdateAt where HealthCheckKey = @HealthCheckKey", entity);
                return entity;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
