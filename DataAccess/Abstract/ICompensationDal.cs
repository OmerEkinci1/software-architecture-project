using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICompensationDal : IEntityRepository<Compensation>
    {
        List<WorkerCompensationDto> GetAll();
        WorkerCompensationDto GetByWorkerID(int workerID);
        List<WorkerCompensationDto> GetByUserID(int userID);
    }
}
