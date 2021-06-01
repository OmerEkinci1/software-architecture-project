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
    public class EfWorkerDal : EfEntityRepositoryBase<Worker, DatabaseContext>, IWorkerDal
    {
        public List<WorkerDto> GetAllWorker()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from worker in db.Workers
                             join user in db.Users on 
                             worker.UserID equals user.UserID
                             where worker.Status == true
                             select new WorkerDto
                             {
                                 WorkerID = worker.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 DailyWorkingTime = worker.DailyWorkingTime,
                                 UserID = user.UserID,
                                 Name = user.Name,                               
                                 HourSalary = worker.HourSalary,
                                 StartTime = worker.StartTime,
                                 Status = worker.Status,
                                 DepartmentTypes=db.DepartmentTypes.Where(d=>db.WorkerDepartmentTypes.Where(wd=>wd.WorkerID==worker.WorkerID).Select(p=>p.DepartmentTypeID).Contains(d.DepartmentTypeID)).ToList()                                


                             };
                return result.ToList();
            }
        }

        public List<Worker> GetAllWorkerByStatusFalse()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from worker in db.Workers
                             where worker.Status == false
                             select new Worker
                             {
                                 WorkerID = worker.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 UserID = worker.UserID,
                                 WorkerSurname = worker.WorkerSurname,
                                 DailyWorkingTime = worker.DailyWorkingTime,
                                 HourSalary = worker.HourSalary,
                                 StartTime = worker.StartTime,
                                 Status = worker.Status,                         


                             };
                return result.ToList();
            }
        }
    }
}