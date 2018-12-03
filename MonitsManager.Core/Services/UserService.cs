using MonitsManager.Core.Interfaces.Repository;
using MonitsManager.Core.Interfaces.Services;
using MonitsManager.Domain;
using MonitsManager.Models.Exceptions;
using System;

namespace MonitsManager.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Delete(Guid key)
        {
            if (Get(key) == null)
                throw new NotFoundException("User not found");

            try
            {
                return _userRepository.Delete(key);
            }
            catch (Exception)
            {
                throw new InternalServerErrorException("Not possible delete the user");
            }
        }

        public User Get(Guid key)
        {
            var user = _userRepository.Get(key);

            if (user == null)
                throw new NotFoundException("User not found");

            return user;
        }

        public User Insert(User entity)
        {
            try
            {
                entity.UserKey = Guid.NewGuid();

                var hasUser = _userRepository.Exists(entity);

                if (!hasUser)
                    return _userRepository.Insert(entity);
            }
            catch (Exception)
            {
                throw new InternalServerErrorException("Not was possible insert the user");
            }

            throw new ForbbidenException("User already exists");
        }

        public User Update(User entity)
        {
            var user = Get(entity.UserKey);

            if (user.Mail != entity.Mail && _userRepository.Exists(entity.Mail))
                throw new ForbbidenException("Mail already exists");

            if (user.DocumentType != entity.DocumentType)
                throw new ForbbidenException("DocumentType can't be updated");

            if (user.DocumentNumber != entity.DocumentNumber)
                throw new ForbbidenException("DocumentNumber can't be updated");

            try
            {
                return _userRepository.Update(entity);
            }
            catch (Exception)
            {
                throw new InternalServerErrorException("Not was possible update the user");
            }
        }
    }
}
