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
    public class SalaryManager : ISalaryService
    {
        private ISalaryDal _salaryDal;

        public SalaryManager(ISalaryDal salaryDal)
        {
            _salaryDal = salaryDal;
        }

        public IResult Add(Salary salary)
        {
            _salaryDal.Add(salary);
            return new SuccessResult(Messages.SalaryAdded);
        }

        //public IResult Delete(Salary salary)
        //{
        //    _salaryDal.Delete(salary);
        //    return new SuccessResult(Messages.SalaryDeleted);
        //}
        public IResult Update(Salary salary)
        {
            _salaryDal.Update(salary);
            return new SuccessResult(Messages.SalaryUpdated);
        }
        public IDataResult<List<WorkerSalaryDto>> GetAll()
        {
            return new SuccessDataResult<List<WorkerSalaryDto>>(_salaryDal.GetAll());
        }

        public IDataResult<List<WorkerSalaryDto>> GetByUserID(int userID)
        {
            return new SuccessDataResult<List<WorkerSalaryDto>>(_salaryDal.GetByUserID(userID));
        }

        public IDataResult<WorkerSalaryDto> GetByWorkerID(int workerID)
        {
            return new SuccessDataResult<WorkerSalaryDto>(_salaryDal.GetWorkerID(workerID));
        }


    }
}
