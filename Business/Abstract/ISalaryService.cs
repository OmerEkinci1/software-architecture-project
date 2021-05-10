using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISalaryService
    {
        IResult Add(Salary salary);
        IResult Update(Salary salary);
        //IResult Delete(Salary salary);
        IDataResult<WorkerSalaryDto> GetByWorkerID(int workerID);
        IDataResult<List<WorkerSalaryDto>> GetAll();
        IDataResult<List<WorkerSalaryDto>> GetByUserID(int userID);

    }
}
