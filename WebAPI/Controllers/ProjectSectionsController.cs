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
    public class ProjectSectionsController : ControllerBase
    {
        private IProjectSectionService _projectSectionService;
        private IProjectService _projectService;

        public ProjectSectionsController(IProjectSectionService projectSectionService, IProjectService projectService)
        {
            _projectSectionService = projectSectionService;
            _projectService = projectService;
        }

        [HttpPost("add")]
        public ActionResult Add(ProjectSection projectSection)
        {
            var result = _projectSectionService.Add(projectSection);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public ActionResult Delete(ProjectSection projectSection)
        {
            var result = _projectSectionService.Delete(projectSection);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public ActionResult Update(ProjectSection projectSection)
        {
            var result = _projectSectionService.Update(projectSection);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyprojectid")]
        public ActionResult GetByProjectID(int projectID)
        {
            var result = _projectSectionService.GetByProjectID(projectID);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
