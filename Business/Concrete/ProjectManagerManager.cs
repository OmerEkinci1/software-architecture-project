using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProjectManagerManager : IProjectManagerService
    {
        private IProjectManagerService _projectManagerService;

        public ProjectManagerManager(IProjectManagerService projectManagerService)
        {
            _projectManagerService = projectManagerService;
        }
    }
}
