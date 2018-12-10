using Microsoft.AspNetCore.Mvc;
using MonitsManager.Application.Interfaces;
using MonitsManager.Models.Common;
using MonitsManager.Models.HealthCheck;
using MonitsManager.Models.HealthCheck.Samples;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Linq;
using System.Net;

namespace MonitsManager.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthChecksController : ControllerBase
    {
        private readonly IHealthCheckAppService _healthCheckAppService;

        public HealthChecksController(IHealthCheckAppService healthCheckAppService)
        {
            _healthCheckAppService = healthCheckAppService;
        }

        /// <summary>
        /// Get healthCheck
        /// </summary>
        [HttpGet("{HealthCheckKey}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(HealthCheckResponseOkModel))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(HealthCheckResponseOkSample))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResponseModel))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(HealthCheckResponseNotFoundSample))]
        public IActionResult Get(Guid HealthCheckKey)
        {
            var response = this._healthCheckAppService.Get(HealthCheckKey);
            return new ObjectResult(response) { StatusCode = response.StatusCode() };
        }

        /// <summary>
        /// Insert healthCheck
        /// </summary>
        [HttpPost]
        [Consumes("application/json")]
        [SwaggerRequestExample(typeof(HealthCheckRequestModel), typeof(HealthCheckRequestSample))]
        [SwaggerResponse((int)HttpStatusCode.Created, Type = typeof(HealthCheckResponseCreatedModel))]
        [SwaggerResponseExample((int)HttpStatusCode.Created, typeof(HealthCheckResponseCreatedSample))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(HealthCheckResponseBadRequestSample))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = typeof(ForbiddenResponseModel))]
        [SwaggerResponseExample((int)HttpStatusCode.Forbidden, typeof(HealthCheckResponseForbiddenSample))]
        public IActionResult Post([FromBody] HealthCheckRequestModel healthCheckRequest)
        {
            if (ModelState.IsValid)
            {
                var response = _healthCheckAppService.Insert(healthCheckRequest);
                return new ObjectResult(response) { StatusCode = response.StatusCode() };
            }

            var badRequest = new BadRequestResponse($"Required: {String.Join(',', ModelState.Keys.ToArray())}");
            return new ObjectResult(badRequest) { StatusCode = badRequest.StatusCode() };
        }

        /// <summary>
        /// Put healthCheck
        /// </summary>
        [HttpPut("{HealthCheckKey}")]
        [SwaggerRequestExample(typeof(HealthCheckRequestModel), typeof(HealthCheckRequestSample))]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(HealthCheckResponseOkModel))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(HealthCheckResponseOkSample))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResponseModel))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(HealthCheckResponseNotFoundSample))]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, Type = typeof(ForbiddenResponseModel))]
        [SwaggerResponseExample((int)HttpStatusCode.Forbidden, typeof(HealthCheckResponseForbiddenSample))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestResponse))]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(HealthCheckResponseBadRequestSample))]
        public IActionResult Put(Guid HealthCheckKey, [FromBody] HealthCheckRequestModel healthCheckRequest)
        {
            if (ModelState.IsValid)
            {
                var response = _healthCheckAppService.Update(HealthCheckKey, healthCheckRequest);
                return new ObjectResult(response) { StatusCode = response.StatusCode() };
            }

            var badRequest = new BadRequestResponse($"Required: {String.Join(',', ModelState.Keys.ToArray())}");
            return new ObjectResult(badRequest) { StatusCode = badRequest.StatusCode() };
        }

        /// <summary>
        /// Delete healthCheck
        /// </summary>
        [HttpDelete("{HealthCheckKey}")]
        [SwaggerResponse((int)HttpStatusCode.Accepted, Type = typeof(AcceptResponseModel))]
        [SwaggerResponseExample((int)HttpStatusCode.Accepted, typeof(HealthCheckResponseCreatedSample))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResponseModel))]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(HealthCheckResponseNotFoundSample))]
        public IActionResult Delete(Guid HealthCheckKey)
        {
            var response = _healthCheckAppService.Delete(HealthCheckKey);
            return new ObjectResult(response) { StatusCode = response.StatusCode() };
        }
    }
}
