using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ISalaryDal : IEntityRepository<Salary>
    {
        WorkerSalaryDto GetWorkerID(int workerID);
        List<WorkerSalaryDto> GetAll();
        List<WorkerSalaryDto> GetByUserID(int userID);
    }
}
