using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProjectWorkerDal : EfEntityRepositoryBase<ProjectWorker, DatabaseContext>, IProjectWorkerDal
    {
        public List<ProjectWorkersDto> GetAllProjectWorkers()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from projectworkers in db.ProjectWorkers
                             join worker in db.Workers on
                             projectworkers.WorkerID equals worker.WorkerID
                             join project in db.Projects on
                             projectworkers.ProjectID equals project.ProjectID
                             join department in db.DepartmentTypes on
                             worker.DepartmentTypeID equals department.DepartmentTypeID
                             select new ProjectWorkersDto
                             {
                                 ProjectWorkerID = projectworkers.ProjectWorkerID,
                                 WorkerID = worker.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 ProjectID = project.ProjectID,
                                 ProjectName = project.ProjectName,
                                 Subject = project.Subject,
                                 DepartmentTypeID = department.DepartmentTypeID,
                                 DepartmentTypeName = department.DepartmentTypeName
                             };
                return result.ToList();

            }
        }
    }
}
