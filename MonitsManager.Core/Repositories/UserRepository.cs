using Dapper;
using MonitsManager.Core.Interfaces.Repository;
using MonitsManager.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MonitsManager.Core.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbConnection connection) : base(connection){}

        public override bool Delete(Guid key)
        {
            try
            {
                _connection.Open();
                return _connection.Execute("DELETE FROM User WHERE UserKey = @UserKey", new { UserKey = key }) > 0;
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

        public bool Exists(User user)
        {
            try
            {
                _connection.Open();
                return _connection.QueryFirstOrDefault<bool>("SELECT 1 FROM User WHERE Mail = @Mail or UserKey = @UserKey or (DocumentNumber = @DocumentNumber and DocumentType = @DocumentType) LIMIT 1", new { Email = user.Mail, UserKey = user.UserKey, DocumentNumber = user.DocumentNumber, DocumentType = user.DocumentType });
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

        public bool Exists(string mail)
        {
            try
            {
                _connection.Open();
                return _connection.QueryFirstOrDefault<bool>("SELECT 1 FROM User WHERE Mail = @Mail LIMIT 1", new { Mail = mail });
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

        public override User Get(Guid key)
        {
            try
            {
                _connection.Open();
                return _connection.QueryFirstOrDefault<User>("SELECT * FROM User WHERE UserKey = @UserKey LIMIT 1", new { UserKey = key });
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

        public override User Insert(User entity)
        {
            try
            {
                _connection.Open();
                _connection.Execute("INSERT INTO User (UserKey, Nome, Mail, Phone, DocumentNumber, DocumentType, Password) VALUES (@UserKey, @Nome, @Mail, @Phone, @DocumentNumber, @DocumentType, @Password)", entity);
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

        public override User Update(User entity)
        {
            try
            {
                _connection.Open();
                _connection.Execute("UPDATE User SET Name = @Name, Mail = @Mail, Phone = @Phone, DocumentNumber = @DocumentNumber, DocumentType = @DocumentType, Password = @Password where UserKey = @UserKey", entity);
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
