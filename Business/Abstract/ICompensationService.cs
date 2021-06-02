using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICompensationService
    {
        IResult Add(Compensation compensation);
        IResult Update(Compensation compensation);
        //IResult Delete(Compensation compensation);
        IDataResult<WorkerCompensationDto> SuggestionByWorkerID(int workerID);
        IDataResult<WorkerCompensationDto> GetByWorkerID(int workerID);
        IDataResult<List<WorkerCompensationDto>>GetByUserID(int userID);
        IDataResult<List<WorkerCompensationDto>> GetAll();
    }
}
