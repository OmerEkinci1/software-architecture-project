using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProjectWorkerDal : IEntityRepository<ProjectWorker>
    {
        ProjectWorkerDto GetByProjectSectionDepartmentID(int projectSectionDepartmentID);
        List<ProjectWorkerDto> GetAll(); 
        List<ProjectWorkerDto> GetByWorkerID(int workerID);

    }
}
