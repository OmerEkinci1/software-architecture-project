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
    public class ProjectGeneralController : ControllerBase
    {
        private IProjectGeneralService _projectGeneralService;
        private IProjectService _projectService;

        public ProjectGeneralController(IProjectGeneralService projectGeneralService, IProjectService projectService)
        {
            this._projectGeneralService = projectGeneralService;
            this._projectService = projectService;
        }

        [HttpPost("add")]
        public ActionResult Add(ProjectCreationDto projectCreationDto)
        {
            var result = _projectGeneralService.Add(projectCreationDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public ActionResult Delete(int projectID)
        {
            var result = _projectGeneralService.Delete(projectID);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public ActionResult Update(Project project)
        {
            var result = _projectService.Update(project);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getprojectbyprojectid")]
        public ActionResult GetProjectByProjectID(int projectID)
        {
            var result = _projectGeneralService.GetProjectByProjectID(projectID);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()   //?neden
        {
            var result = _projectService.GetAll();
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
