using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProjectWorkerWorkingTimeManager : IProjectWorkerWorkingTimeService
    {
        private IProjectWorkerWorkingTimeDal _projectWorkerWorkingTimeDal;

        public ProjectWorkerWorkingTimeManager(IProjectWorkerWorkingTimeDal projectWorkerWorkingTimeDal)
        {
            _projectWorkerWorkingTimeDal = projectWorkerWorkingTimeDal;
        }
    }
}
