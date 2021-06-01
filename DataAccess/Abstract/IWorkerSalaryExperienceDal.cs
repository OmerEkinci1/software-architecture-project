using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IWorkerSalaryExperienceDal : IEntityRepository<WorkerSalaryExperience>
    {
        List<WorkerSalaryExperienceDto> GetByDepartmentTypeID(int departmentTypeID);
        List<WorkerSalaryExperienceDto> GetAll();
    }
}
