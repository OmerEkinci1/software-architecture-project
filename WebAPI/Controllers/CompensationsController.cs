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
    public class CompensationsController : ControllerBase
    {
        private ICompensationService _compensationService;

        public CompensationsController(ICompensationService compensationService)
        {
            _compensationService = compensationService;
        }

        [HttpPost("add")]
        public ActionResult Add(Compensation compensation)
        {
            var result = _compensationService.Add(compensation);
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
        public ActionResult Update(Compensation compensation)
        {
            var result = _compensationService.Update(compensation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public ActionResult Get()
        {
            var result = _compensationService.GetAll();
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("suggestion")]
        public ActionResult Suggestion(int workerID)
        {
            if (workerID == 0)
            {
                return BadRequest();
            }
            var result = _compensationService.SuggestionByWorkerID(workerID);         
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public ActionResult GetByUserID(Compensation compensation)
        {
            var result = _compensationService.GetByUserID(compensation.UserID);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyworkerid")]
        public ActionResult GetByWorkerID(Compensation compensation)
        {
            var result = _compensationService.GetByWorkerID(compensation.WorkerID);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
