using Microsoft.AspNetCore.Mvc;
using MonitsManager.Application.Interfaces;
using MonitsManager.Models.Common;
using MonitsManager.Models.User;
using MonitsManager.Models.User.Samples;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Linq;
using System.Net;

namespace MonitsManager.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        /// <summary>
        /// Get user
        /// </summary>
        [HttpGet("{UserKey}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UserResponseOkModel))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UserResponseOkSample))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResponseModel))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(UserResponseNotFoundSample))]
        public IActionResult Get(Guid UserKey)
        {
            var response = this._userAppService.Get(UserKey);
            return new ObjectResult(response) { StatusCode = response.StatusCode() };
        }

        /// <summary>
        /// Insert user
        /// </summary>
        [HttpPost]
        [Consumes("application/json")]
        [SwaggerRequestExample(typeof(UserRequestModel), typeof(UserRequestSample))]
        [SwaggerResponse((int)HttpStatusCode.Created, Type = typeof(UserResponseCreatedModel))]
        [SwaggerResponseExample((int)HttpStatusCode.Created, typeof(UserResponseCreatedSample))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(UserResponseBadRequestSample))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = typeof(ForbiddenResponseModel))]
        [SwaggerResponseExample((int)HttpStatusCode.Forbidden, typeof(UserResponseForbiddenSample))]
        public IActionResult Post([FromBody] UserRequestModel userRequest)
        {
            if (ModelState.IsValid)
            {
                var response = _userAppService.Insert(userRequest);
                return new ObjectResult(response) { StatusCode = response.StatusCode() };
            }

            var badRequest = new BadRequestResponse($"Required: {String.Join(',', ModelState.Keys.ToArray())}");
            return new ObjectResult(badRequest) { StatusCode = badRequest.StatusCode() };
        }

        /// <summary>
        /// Put user
        /// </summary>
        [HttpPut("{UserKey}")]
        [SwaggerRequestExample(typeof(UserRequestModel), typeof(UserRequestSample))]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(UserResponseOkModel))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UserResponseOkSample))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResponseModel))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(UserResponseNotFoundSample))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = typeof(ForbiddenResponseModel))]
        [SwaggerResponseExample((int)HttpStatusCode.Forbidden, typeof(UserResponseForbiddenSample))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(UserResponseBadRequestSample))]
        public IActionResult Put(Guid UserKey, [FromBody] UserRequestModel userRequest)
        {
            if (ModelState.IsValid)
            {
                var response = _userAppService.Update(UserKey, userRequest);
                return new ObjectResult(response) { StatusCode = response.StatusCode() };
            }

            var badRequest = new BadRequestResponse($"Required: {String.Join(',', ModelState.Keys.ToArray())}");
            return new ObjectResult(badRequest) { StatusCode = badRequest.StatusCode() };
        }

        /// <summary>
        /// Delete user
        /// </summary>
        [HttpDelete("{UserKey}")]
        [SwaggerResponse((int)HttpStatusCode.Accepted, Type = typeof(AcceptResponseModel))]
        [SwaggerResponseExample((int)HttpStatusCode.Accepted, typeof(UserResponseCreatedSample))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResponseModel))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(UserResponseNotFoundSample))]
        public IActionResult Delete(Guid UserKey)
        {
            var response = _userAppService.Delete(UserKey);
            return new ObjectResult(response) { StatusCode = response.StatusCode() };
        }
    }
}
