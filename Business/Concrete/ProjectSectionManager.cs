using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProjectSectionManager : IProjectSectionService
    {
        private IProjectSectionService _projectSectionService;

        public ProjectSectionManager(IProjectSectionService projectSectionService)
        {
            _projectSectionService = projectSectionService;
        }
    }
}
