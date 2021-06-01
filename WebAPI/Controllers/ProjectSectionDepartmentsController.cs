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
    public class ProjectSectionDepartmentsController : ControllerBase
    {
        private IProjectSectionDepartmentService _projectSectionDepartmentService;

        public ProjectSectionDepartmentsController(IProjectSectionDepartmentService projectSectionDepartmentService)
        {
            _projectSectionDepartmentService = projectSectionDepartmentService;
        }

        [HttpPost("add")]
        public ActionResult Add(ProjectSectionDepartment projectSectionDepartment)
        {
            var result = _projectSectionDepartmentService.Add(projectSectionDepartment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public ActionResult Delete(ProjectSectionDepartment projectSectionDepartment)
        {
            var result = _projectSectionDepartmentService.Delete(projectSectionDepartment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public ActionResult Update(ProjectSectionDepartment projectSectionDepartment)
        {
            var result = _projectSectionDepartmentService.Update(projectSectionDepartment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpGet("getbyprojectid")]
        //public ActionResult GetByProjectID(int projectID)
        //{
        //    var result = _projectSectionDepartmentService.GetByProjectID(projectID);
        //    if (result.Data != null)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpGet("getbyuserid")]
        //public ActionResult GetByUserID(int userID)
        //{
        //    var result = _projectSectionDepartmentService.GetByUserID(userID);
        //    if (result.Data != null)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        [HttpGet("getbysectionid")]
        public ActionResult GetBySectionID(int sectionID)
        {
            var result = _projectSectionDepartmentService.GetBySectionID(sectionID);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _projectSectionDepartmentService.GetAll();
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
