using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        private IProjectService _projectService;

        public ProjectManager(IProjectService projectService)
        {
            _projectService = projectService;
        }
    }
}
