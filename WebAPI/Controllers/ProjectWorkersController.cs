using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectWorkersController : ControllerBase
    {
        IProjectWorkerService _projectWorkerService;

        public ProjectWorkersController(IProjectWorkerService projectWorkerService)
        {
            this._projectWorkerService = projectWorkerService;
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _projectWorkerService.GetAll();
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
