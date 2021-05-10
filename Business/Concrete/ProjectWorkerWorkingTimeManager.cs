using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(ProjectWorkerWorkingTime projectWorkerWorkingTime)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProjectWorkerWorkingTimeDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProjectWorkerWorkingTimeDto>> GetByProjectWorkerID(int projectWorkerID)
        {
            throw new NotImplementedException();
        }

        public IResult Update(ProjectWorkerWorkingTime projectWorkerWorkingTime)
        {
            throw new NotImplementedException();
        }
    }
}
