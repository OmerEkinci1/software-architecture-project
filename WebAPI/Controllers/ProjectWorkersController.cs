using Business.Abstract;
using Entities.Concrete;
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
            _projectWorkerService = projectWorkerService;
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

        [HttpPost("add")]
        public ActionResult Add(ProjectWorker projectWorker)
        {
            var result = _projectWorkerService.Add(projectWorker);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public ActionResult Update(ProjectWorker projectWorker)
        {
            var result = _projectWorkerService.Update(projectWorker);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public ActionResult Delete(int projectWorkerID)
        {
            var result = _projectWorkerService.Delete(projectWorkerID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
