using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IWorkerService
    {
        IResult Add(Worker worker);
        IResult Update(Worker worker);
        IResult Delete(Worker worker);

        IDataResult<Worker> Get(int workerID);
        IDataResult<List<Worker>> GetAll();
    }
}
