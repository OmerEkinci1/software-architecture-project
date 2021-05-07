using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
            _workerDal.Add(worker);
            return new SuccessResult(Messages.WorkerAdded);
        }

        public IResult Delete(Worker worker)
        {
            _workerDal.Delete(worker);
            return new SuccessResult(Messages.WorkerDeleted);
        }

        public IDataResult<Worker> Get(int workerID)
        {
            return new SuccessDataResult<Worker>(_workerDal.Get(w => w.WorkerID == workerID));
        }

        public IDataResult<List<Worker>> GetAll()
        {
            return new SuccessDataResult<List<Worker>>(_workerDal.GetAll());
        }

        public IResult Update(Worker worker)
        {
            _workerDal.Update(worker);
            return new SuccessResult(Messages.WorkerUpdated);
        }
    }
}
