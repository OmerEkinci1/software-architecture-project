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
    public class WorkerSalaryExperiencesController : ControllerBase
    {
        IWorkerSalaryExperienceService _workerSalaryExperienceService;

        public WorkerSalaryExperiencesController(IWorkerSalaryExperienceService workerSalaryExperienceService)
        {
            _workerSalaryExperienceService = workerSalaryExperienceService;
        }

        [HttpPost("add")]
        public ActionResult Add(WorkerSalaryExperience workerSalaryExperience)
        {
            var result = _workerSalaryExperienceService.Add(workerSalaryExperience);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public ActionResult Update(WorkerSalaryExperience workerSalaryExperience)
        {
            var result = _workerSalaryExperienceService.Update(workerSalaryExperience);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _workerSalaryExperienceService.GetAll();
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbydepartmenttypeid")]
        public ActionResult GetByDepartmentTypeID(int departmentTypeID)
        {
            var result = _workerSalaryExperienceService.GetByDepartmentTypeID(departmentTypeID);
            if (result.Data!=null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
