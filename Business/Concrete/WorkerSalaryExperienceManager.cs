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
    public class WorkerSalaryExperienceManager : IWorkerSalaryExperienceService
    {
        private IWorkerSalaryExperienceDal _workerSalaryExperienceDal;

        public WorkerSalaryExperienceManager(IWorkerSalaryExperienceDal workerSalaryExperienceDal)
        {
            _workerSalaryExperienceDal = workerSalaryExperienceDal;
        }

        public IResult Add(WorkerSalaryExperience workerSalaryExperience)
        {
            _workerSalaryExperienceDal.Add(workerSalaryExperience);
            return new SuccessResult(Messages.WorkerSalaryExperienceAdded);
        }
        public IResult Update(WorkerSalaryExperience workerSalaryExperience)
        {
            _workerSalaryExperienceDal.Update(workerSalaryExperience);
            return new SuccessResult(Messages.WorkerSalaryExperienceUpdated);
        }

        public IDataResult<List<WorkerSalaryExperienceDto>> GetByDepartmentTypeID(int departmentTypeID)
        {
            return new SuccessDataResult<List<WorkerSalaryExperienceDto>>(_workerSalaryExperienceDal.GetByDepartmentTypeID(departmentTypeID));
        }

        public IDataResult<List<WorkerSalaryExperienceDto>> GetAll()
        {
            return new SuccessDataResult<List<WorkerSalaryExperienceDto>>(_workerSalaryExperienceDal.GetAll());
        }
    }
}
