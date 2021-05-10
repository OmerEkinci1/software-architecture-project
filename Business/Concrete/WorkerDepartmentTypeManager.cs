using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class WorkerDepartmentTypeManager : IWorkerDepartmentTypeService
    {
        private IWorkerDepartmentTypeDal _workerDepartmentTypeDal;

        public WorkerDepartmentTypeManager(IWorkerDepartmentTypeDal workerDepartmentTypeDal)
        {
            _workerDepartmentTypeDal = workerDepartmentTypeDal;
        }

        public IResult Add(WorkerDepartmentType workerDepartmentType)
        {
            _workerDepartmentTypeDal.Add(workerDepartmentType);
            return new SuccessResult(Messages.WorkerDepartmentTypeAdded);
        }

        public IResult Delete(WorkerDepartmentType workerDepartmentType)
        {
            _workerDepartmentTypeDal.Delete(workerDepartmentType);
            return new SuccessResult(Messages.WorkerDepartmentTypeDeleted);
        }

        public IDataResult<List<WorkerDepartmentDto>> GetAllByDepartmentTypeID(int departmentTypeID)
        {
            return new SuccessDataResult<List<WorkerDepartmentDto>>(_workerDepartmentTypeDal.GetAllByDepartmentTypeID(departmentTypeID));
        }

        public IDataResult<List<WorkerDepartmentDto>> GetByWorkerID(int workerID)
        {
            return new SuccessDataResult<List<WorkerDepartmentDto>>(_workerDepartmentTypeDal.GetByWorkerID(workerID));
        }
    }
}
