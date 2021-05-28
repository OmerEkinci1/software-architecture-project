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
    public class SalariesController : ControllerBase
    {
        private ISalaryService _salaryService;

        public SalariesController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }


        [HttpPost("add")]
        public ActionResult Add(Salary salary)
        {
            var result = _salaryService.Add(salary);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpPost("delete")]
        //public ActionResult Delete(Compensation compensation)
        //{
        //    var result = _compensationService.Delete(compensation);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpPost("update")]
        public ActionResult Update(Salary salary)
        {
            var result = _salaryService.Update(salary);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public ActionResult Get()
        {
            var result = _salaryService.GetAll();
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public ActionResult GetByUserID(Salary salary)
        {
            var result = _salaryService.GetByUserID(salary.UserID);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyworkerid")]
        public ActionResult GetByWorkerID(Salary salary)
        {
            var result = _salaryService.GetByWorkerID(salary.WorkerID);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
