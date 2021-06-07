using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
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
            IResult result = BusinessRules.Run(CheckWorkerHaveSalaryThisMonth(salary));
            if (result!=null)
            {
                return result;
            }

            _salaryDal.Add(salary);
            return new SuccessResult(Messages.SalaryAdded);
        }

        public IResult Update(Salary salary)
        {
            _salaryDal.Update(salary);
            return new SuccessResult(Messages.SalaryUpdated);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<WorkerSalaryDto>> GetAll()
        {
            return new SuccessDataResult<List<WorkerSalaryDto>>(_salaryDal.GetAll());
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<WorkerSalaryDto>> GetByUserID(int userID)
        {
            return new SuccessDataResult<List<WorkerSalaryDto>>(_salaryDal.GetByUserID(userID));
        }

        [CacheAspect(duration: 10)]
        public IDataResult<WorkerSalaryDto> GetByWorkerID(int workerID)
        {
            return new SuccessDataResult<WorkerSalaryDto>(_salaryDal.GetWorkerID(workerID));
        }


        private IResult CheckWorkerHaveSalaryThisMonth(Salary salary)
        {
            var getLastSalary = _salaryDal.GetWorkerID(salary.WorkerID).SalaryDate;
            var a = Convert.ToDateTime(salary.SalaryDate);
            var b = Convert.ToDateTime(getLastSalary);
            var x = (a - b).Days;
            if (x>= 30)
            {
                Salary salaryNew = new Salary
                {
                    UserID = salary.UserID,
                    WorkerID = salary.WorkerID,
                    SalaryAmount = salary.SalaryAmount
                };
                _salaryDal.Add(salaryNew);
                return new SuccessResult(Messages.SalaryAdded);
            }
            return new ErrorResult(Messages.SalaryAlreadyExistThisMonth);

        }

    }
}
