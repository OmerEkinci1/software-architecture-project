using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CompensationManager : ICompensationService
    {
        private ICompensationDal _compensationDal;

        public CompensationManager(ICompensationDal compensationDal)
        {
            _compensationDal = compensationDal;
        }

        public IResult Add(Compensation compensation)
        {
            IResult result = BusinessRules.Run(CheckIfUserHasCompensation(compensation));
            if (result!=null)
            {
                return result;
            }
            _compensationDal.Add(compensation);
            return new SuccessResult(Messages.CompensationAdded);
        }

        public IDataResult<List<WorkerCompensationDto>> GetAll()
        {
            return new SuccessDataResult<List<WorkerCompensationDto>>(_compensationDal.GetAll(), Messages.CompensationListed);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<WorkerCompensationDto>> GetByUserID(int userID)
        {
            return new SuccessDataResult<List<WorkerCompensationDto>>(_compensationDal.GetByUserID(userID), Messages.UserListed);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<WorkerCompensationDto> GetByWorkerID(int workerID)
        {
            return new SuccessDataResult<WorkerCompensationDto>(_compensationDal.GetByWorkerID(workerID), Messages.WorkerListed);
        }

        public IDataResult<WorkerCompensationDto> SuggestionByWorkerID(int workerID)
        {
            var GetByWorkerID = _compensationDal.GetByWorkerID(workerID);
            var getDate = (DateTime.Now - GetByWorkerID.StartDate).Days;
            switch (getDate)
            {
                case 1:
                    if (getDate < 365)
                    {
                        GetByWorkerID.CompensationAmount = ((GetByWorkerID.HourSalary * getDate)/4);
                        break;
                    }
                    break;
                case 2:
                    if (getDate >= 365 && getDate <= 730)
                    {
                        GetByWorkerID.CompensationAmount = ((GetByWorkerID.HourSalary * getDate) / 3);
                        break;
                    }
                    break;
                case 3:
                    if (getDate >= 730)
                    {
                        GetByWorkerID.CompensationAmount = (GetByWorkerID.HourSalary * getDate);
                        break;
                    }
                    break;
            }
            return new SuccessDataResult<WorkerCompensationDto>(GetByWorkerID);
        }

        public IResult Update(Compensation compensation)
        {
            _compensationDal.Update(compensation);
            return new SuccessResult(Messages.CompensationUpdated);
        }

        private IResult CheckIfUserHasCompensation(Compensation compensation)
        {
            var result=_compensationDal.Get(c => c.WorkerID == compensation.WorkerID);
            if (result!=null)
            {
                if (result.CompensationID!=compensation.CompensationID)
                {
                    return new ErrorResult(Messages.UserAlreadyHaveCompensation);
                }
            }
            return new SuccessResult();
        }

    }
}
