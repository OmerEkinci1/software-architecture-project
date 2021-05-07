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
    public class EfProjectWorkerWorkingTimeDal : EfEntityRepositoryBase<ProjectWorkerWorkingTime, DatabaseContext>, IProjectWorkerWorkingTimeDal
    {
        public List<ProjectWorkerWorkingTimeDto> GetAll()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from pwwt in db.ProjectWorkerWorkingTimes
                             join projectworker in db.ProjectWorkers on
                             pwwt.ProjectWorkerID equals projectworker.ProjectWorkerID
                             join worker in db.Workers on
                             projectworker.WorkerID equals worker.WorkerID
                             join project in db.Projects on
                             projectworker.ProjectID equals project.ProjectID
                             join manager in db.ProjectManagers on
                             project.ManagerID equals manager.ManagerID
                             select new ProjectWorkerWorkingTimeDto
                             {
                                 ProjectWorkerWorkingTimeID = pwwt.ProjectWorkerWorkingTimeID,
                                 ProjectWorkerID = projectworker.ProjectWorkerID,
                                 WorkerID = projectworker.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 DailyStartHour = pwwt.DailyStartHour,
                                 DailyFinishHour = pwwt.DailyFinishHour,
                                 Date = pwwt.Date,
                                 ProjectID = projectworker.ProjectID,
                                 ProjectName = project.ProjectName,
                                 Subject = project.Subject,
                                 ManagerID = project.ManagerID,
                                 ManagerName = manager.ManagerName,
                                 ManagerSurname = manager.ManagerSurname
                             };
                return result.ToList();
            }
        }
    }
}
