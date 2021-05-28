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
        public List<WorkerDto> GetAll()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from worker in db.Workers
                             join wdt in db.WorkerDepartmentTypes on
                             worker.WorkerID equals wdt.WorkerID
                             where worker.Status == true
                             select new WorkerDto
                             {
                                 WorkerID = worker.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 DailyWorkingTime = worker.DailyWorkingTime,
                                 HourSalary = worker.HourSalary,
                                 StartTime = worker.StartTime,
                                 Status = worker.Status,
                                 DepartmentType = db.DepartmentTypes.Where(p => p.DepartmentTypeID == wdt.DepartmentTypeID).ToList(),


                             };
                return result.ToList();
            }
        }
    }
}