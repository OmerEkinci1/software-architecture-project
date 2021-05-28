using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
    public class WorkersController : ControllerBase
    {
        private IWorkerService _workerService;

        public WorkersController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpPost("add")]
        public ActionResult Add(WorkerCreationDto workerCreationDto)
        {
            var result = _workerService.Add(workerCreationDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public ActionResult Delete(Worker worker)
        {
            var result = _workerService.Delete(worker);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public ActionResult Update(Worker worker)
        {
            var result = _workerService.Update(worker);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _workerService.GetAll();
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallworkerstatusfalse")]
        public ActionResult GetAllWorkerStatusFalse()
        {
            var result = _workerService.GetAllWorkersByStatusFalse();
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
