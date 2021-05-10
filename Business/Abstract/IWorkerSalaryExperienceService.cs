using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWorkerSalaryExperienceService
    {
        IResult Add(WorkerSalaryExperience workerSalaryExperience);
        IResult Update(WorkerSalaryExperience workerSalaryExperience);
        IDataResult<List<WorkerSalaryExperienceDto>> GetByDepartmentTypeID(int departmentTypeID);
    }
}
