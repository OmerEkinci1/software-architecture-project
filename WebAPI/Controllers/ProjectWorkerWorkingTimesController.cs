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
    public class ProjectWorkerWorkingTimesController : ControllerBase
    {
        private IProjectWorkerWorkingTimeService _projectWorkerWorkingTimeService;

        public ProjectWorkerWorkingTimesController(IProjectWorkerWorkingTimeService projectWorkerWorkingTimeService)
        {
            _projectWorkerWorkingTimeService = projectWorkerWorkingTimeService;
        }

        [HttpPost("add")]
        public ActionResult Add(ProjectWorkerWorkingTime projectWorkerWorkingTime)
        {
            var result = _projectWorkerWorkingTimeService.Add(projectWorkerWorkingTime);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public ActionResult Update(ProjectWorkerWorkingTime projectWorkerWorkingTime)
        {
            var result = _projectWorkerWorkingTimeService.Update(projectWorkerWorkingTime);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _projectWorkerWorkingTimeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyprojectworkerid")]
        public ActionResult GetByProjectWorkerID(int projectWorkerID)
        {
            var result = _projectWorkerWorkingTimeService.GetByProjectWorkerID(projectWorkerID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
