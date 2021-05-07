using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProjectWorkerManager : IProjectWorkerService
    {
        private IProjectWorkerService _projectWorkerService;

        public ProjectWorkerManager(IProjectWorkerService projectWorkerService)
        {
            _projectWorkerService = projectWorkerService;
        }
    }
}
