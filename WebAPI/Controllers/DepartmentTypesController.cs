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
    public class DepartmentTypesController : ControllerBase
    {
        private IDepartmentTypeService _departmentTypeService;

        public DepartmentTypesController(IDepartmentTypeService departmentTypeService)
        {
            _departmentTypeService = departmentTypeService;
        }

        [HttpPost("add")]
        public ActionResult Add(DepartmentType departmentType)
        {
            var result = _departmentTypeService.Add(departmentType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public ActionResult Update(DepartmentType departmentType)
        {
            var result = _departmentTypeService.Update(departmentType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _departmentTypeService.GetAll();
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
