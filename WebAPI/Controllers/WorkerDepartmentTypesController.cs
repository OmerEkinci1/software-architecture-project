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
    public class WorkerDepartmentTypesController : ControllerBase
    {
        private IWorkerDepartmentTypeService _workerDepartmentTypeService;

        public WorkerDepartmentTypesController(IWorkerDepartmentTypeService workerDepartmentTypeService)
        {
            _workerDepartmentTypeService = workerDepartmentTypeService;
        }

        [HttpPost("add")]
        public ActionResult Add(WorkerDepartmentType workerDepartmentType)
        {
            var result = _workerDepartmentTypeService.Add(workerDepartmentType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public ActionResult Delete(WorkerDepartmentType workerDepartmentType)
        {
            var result = _workerDepartmentTypeService.Delete(workerDepartmentType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getallbydepartmenttypeid")]
        public ActionResult GetByProjectID(int departmentTypeID)
        {
            var result = _workerDepartmentTypeService.GetAllByDepartmentTypeID(departmentTypeID);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
