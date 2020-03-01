using ApiTemplate.Api.Dtos.Generic;
using ApiTemplate.Api.Utils;
using ApiTemplate.Core.Business.ApplicationServices;
using ApiTemplate.Core.Business.Dtos.WorkerDtos;
using ApiTemplate.Core.Utils.Extensions.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiTemplate.Api.Controllers
{
    /// <summary>
    /// Controla las operaciones sobre los trabajadores
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[Controller]")]
    [Auth(Policy = ApiTemplateApiPolicies.ApiTemplateApiPolicy)]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerSvc;

        public WorkersController(IWorkerService workerSvc)
        {
            _workerSvc = workerSvc;
        }

        /// <summary>
        /// Obtiene los trabajadores del sistema
        /// </summary>
        /// <returns>Listado de fichajes</returns>
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok(new ResponseDto<IEnumerable<WorkerDto>>
            {
                Result = _workerSvc.GetAll<WorkerDto>(),
                Succeeded = true
            });
        }
    }
}