using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IWorkerDepartmentTypeDal:IEntityRepository<WorkerDepartmentType>
    {
        List<WorkerDepartmentDto> GetAllByDepartmentTypeID(int departmentTypeID);
        List<WorkerDepartmentType> GetByWorkerID(int workerID);
    }
}
