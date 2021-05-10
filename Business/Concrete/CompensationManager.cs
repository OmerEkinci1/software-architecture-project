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


        //public IResult Delete(Compensation compensation)
        //{
        //    _compensationDal.Delete(compensation);
        //    return new SuccessResult(Messages.CompensationDeleted);
        //}

        public IDataResult<List<WorkerCompensationDto>> GetAll()
        {
            return new SuccessDataResult<List<WorkerCompensationDto>>(_compensationDal.GetAll(), Messages.CompensationListed);
        }

        public IDataResult<List<WorkerCompensationDto>> GetByUserID(int userID)
        {
            return new SuccessDataResult<List<WorkerCompensationDto>>(_compensationDal.GetByUserID(userID), Messages.UserListed);
        }

        public IDataResult<WorkerCompensationDto> GetByWorkerID(int workerID)
        {
            return new SuccessDataResult<WorkerCompensationDto>(_compensationDal.GetByWorkerID(workerID), Messages.WorkerListed);
        }

        public IResult Update(Compensation compensation)
        {
            IResult result = BusinessRules.Run(CheckIfUserHasCompensation(compensation));
            if (result != null)
            {
                return result;
            }
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
