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
    public class WorkerManager : IWorkerService
    {
        private IWorkerDal _workerDal;

        public WorkerManager(IWorkerDal workerDal)
        {
            _workerDal = workerDal;
        }

        public IResult Add(Worker worker)
        {
            worker.Status = true;
            _workerDal.Add(worker);
            return new SuccessResult(Messages.WorkerAdded);
        }

        public IResult Delete(Worker worker)
        {
            worker.Status = false;
            var result=Update(worker);
            if (result.Success)
            {
                return new SuccessResult(Messages.WorkerDeleted);

            }
            return new ErrorResult(Messages.NotDeleteWorker);
        }

        public IDataResult<List<WorkerDto>> GetAll()
        {
            return new SuccessDataResult<List<WorkerDto>>(_workerDal.GetAll());
        }

        public IResult Update(Worker worker)
        {
            _workerDal.Update(worker);
            return new SuccessResult(Messages.WorkerUpdated);
        }
    }
}
