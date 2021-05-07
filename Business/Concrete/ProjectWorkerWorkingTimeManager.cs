using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProjectWorkerWorkingTimeManager : IProjectWorkerWorkingTimeService
    {
        private IProjectWorkerWorkingTimeService _projectWorkerWorkingTimeService;

        public ProjectWorkerWorkingTimeManager(IProjectWorkerWorkingTimeService projectWorkerWorkingTimeService)
        {
            _projectWorkerWorkingTimeService = projectWorkerWorkingTimeService;
        }
    }
}
