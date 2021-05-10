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

        public ProjectGeneralController(IProjectGeneralService projectGeneralService)
        {
            this._projectGeneralService = projectGeneralService;
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
        public ActionResult Delete(Project project)
        {
            var result = _projectGeneralService.Delete(project);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getprojectbyprojectid")]
        public ActionResult GetProjectByProjectID(Project project)
        {
            var result = _projectGeneralService.GetProjectByProjectID(project);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
