using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectWorkerService
    {
        IResult Add(ProjectWorker projectWorkers);
        IResult Delete(ProjectWorker projectWorkers);
        IResult Update(ProjectWorker projectWorkers);
        IDataResult<List<ProjectWorkerGeneralDto>> GetAll();
        IDataResult<ProjectWorkerDto> GetByProjectSectionDepartmentID(int projectSectionDepartmentID);
        IDataResult<List<ProjectWorkerGeneralDto>> GetByWorkerID(int workerID);
    }
}
