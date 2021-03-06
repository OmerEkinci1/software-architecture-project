using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWorkerDepartmentTypeService
    {
        IResult Add(WorkerDepartmentType workerDepartmentType);
        IResult Delete(WorkerDepartmentType workerDepartmentType);
        IDataResult<List<WorkerDepartmentDto>> GetAllByDepartmentTypeID(int departmentTypeID);
        IDataResult<List<WorkerDepartmentDto>> GetAll();
        IDataResult<List<WorkerDepartmentType>> GetByWorkerID(int workerID);
        IResult DeleteAllDepartmentByWorkerID(int workerID);
    }
}
