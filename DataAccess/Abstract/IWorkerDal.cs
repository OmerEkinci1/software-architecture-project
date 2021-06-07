using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IWorkerDal : IEntityRepository<Worker>
    {
        List<WorkerDto> GetAllWorker();
        List<Worker> GetAllWorkerByStatusFalse();
    }
}
