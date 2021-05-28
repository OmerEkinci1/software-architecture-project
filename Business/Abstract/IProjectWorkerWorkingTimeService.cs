using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectWorkerWorkingTimeService
    {
        IResult Add(ProjectWorkerWorkingTime projectWorkerWorkingTime);
        //IResult Delete(ProjectWorkerWorkingTime projectWorkerWorkingTime);
        IResult Update(ProjectWorkerWorkingTime projectWorkerWorkingTime);
        IDataResult<List<ProjectWorkerWorkingTimeDto>> GetAll();
        IDataResult<List<ProjectWorkerWorkingTimeDto>> GetByProjectWorkerID(int projectWorkerID);

    }
}
