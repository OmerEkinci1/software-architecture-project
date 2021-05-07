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
    public class CompensationManager : ICompensationService
    {
        private ICompensationDal _compensationDal;

        public CompensationManager(ICompensationDal compensationDal)
        {
            _compensationDal = compensationDal;
        }

        public IResult Add(Compensation compensation)
        {
            _compensationDal.Add(compensation);
            return new SuccessResult(Messages.CompensationAdded);
        }

        public IDataResult<List<WorkerCompensationDto>> GetAll()
        {
            return new SuccessDataResult<List<WorkerCompensationDto>>(_compensationDal.GetAll(), Messages.CompensationListed);
        }

        public IDataResult<WorkerCompensationDto> GetByWorkerID(int workerID)
        {
            return new SuccessDataResult<WorkerCompensationDto>(_compensationDal.GetWorkerCompensation(workerID), Messages.WorkerListed);
        }

        public IResult Update(Compensation compensation)
        {
            _compensationDal.Update(compensation);
            return new SuccessResult(Messages.CompensationUpdated);
        }
    }
}
