using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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

        public IResult DeleteAllDepartmentByWorkerID(int workerID)
        {
            var getDepartments = GetByWorkerID(workerID).Data;
            foreach (var department in getDepartments)
            {
                Delete(department);
            }
            return new SuccessResult();
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<WorkerDepartmentDto>> GetAll()
        {
            return new SuccessDataResult<List<WorkerDepartmentDto>>(_workerDepartmentTypeDal.GetAll());
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<WorkerDepartmentDto>> GetAllByDepartmentTypeID(int departmentTypeID)
        {
            return new SuccessDataResult<List<WorkerDepartmentDto>>(_workerDepartmentTypeDal.GetAllByDepartmentTypeID(departmentTypeID));
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<WorkerDepartmentType>> GetByWorkerID(int workerID)
        {
            return new SuccessDataResult<List<WorkerDepartmentType>>(_workerDepartmentTypeDal.GetByWorkerID(workerID));
        }
    }
}
