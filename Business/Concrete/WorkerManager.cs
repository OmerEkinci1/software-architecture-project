using AutoMapper;
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
        private ISalaryService _salaryService;
        private IMapper _mapper;

        public WorkerManager(IWorkerDal workerDal, ISalaryService salaryService,IMapper mapper)
        {
            _workerDal = workerDal;
            _salaryService = salaryService;
            _mapper = mapper;
        }

        public IResult Add(WorkerCreationDto workerCreationDto)
        {
            var workerMapper = _mapper.Map<Worker>(workerCreationDto);
            workerMapper.Status = true;
            _workerDal.Add(workerMapper);

            Salary salary = new Salary()
            {
                WorkerID = workerMapper.WorkerID,
                UserID = workerCreationDto.UserID,
                SalaryAmount = 0,               

            };

            _salaryService.Add(salary);

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

        public IDataResult<Worker> GetByID(int workerID)
        {
            return new SuccessDataResult<Worker>(_workerDal.Get(w => w.WorkerID == workerID));
        }

        public IResult Update(Worker worker)
        {
            _workerDal.Update(worker);
            return new SuccessResult(Messages.WorkerUpdated);
        }
    }
}
