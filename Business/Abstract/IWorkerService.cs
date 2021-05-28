using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWorkerService
    {
        IResult Add(WorkerCreationDto workerCreationDto);
        IResult Update(Worker worker);
        IResult Delete(Worker worker);        
        IDataResult<List<WorkerDto>> GetAll();
        IDataResult<Worker> GetByID(int workerID);
        IDataResult<List<Worker>> GetAllWorkersByStatusFalse();
    }
}
