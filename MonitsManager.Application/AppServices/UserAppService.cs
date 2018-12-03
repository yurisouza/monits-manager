using MonitsManager.Application.Interfaces;
using MonitsManager.Core.Interfaces.Services;
using MonitsManager.Core.Mapper;
using MonitsManager.Domain;
using MonitsManager.Models.Common;
using MonitsManager.Models.Exceptions;
using MonitsManager.Models.User;
using System;

namespace MonitsManager.Application.AppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        private readonly IMapperAdapter _mapperAdapter;

        public UserAppService(IUserService userService, IMapperAdapter mapperAdapter)
        {
            _userService = userService;
            _mapperAdapter = mapperAdapter;
        }

        public IResponse Delete(Guid key)
        {
            try
            {
                _userService.Delete(key);
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
                var user = _userService.Get(key);
                return _mapperAdapter.Map<User, UserResponseCreatedModel>(user);
            }
            catch (NotFoundException ex)
            {
                return new NotFoundResponseModel(ex.Message);
            }
        }

        public IResponse Insert(UserRequestModel entity)
        {
            try
            {
                var user = _mapperAdapter.Map<UserRequestModel, User>(entity);
                user = _userService.Insert(user);
                return _mapperAdapter.Map<User, UserResponseCreatedModel>(user);
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

        public IResponse Update(Guid key, UserRequestModel entity)
        {
            try
            {
                var user = _mapperAdapter.Map<UserRequestModel, User>(entity);
                user.UserKey = key;
                user = _userService.Update(user);
                return _mapperAdapter.Map<User, UserResponseOkModel>(user);
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
