using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfWorkerDepartmentTypeDal : EfEntityRepositoryBase<WorkerDepartmentType, DatabaseContext>, IWorkerDepartmentTypeDal
    {

        public List<WorkerDepartmentDto> GetAllByDepartmentTypeID(int departmentTypeID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from wdt in db.WorkerDepartmentTypes
                             join worker in db.Workers on
                             wdt.WorkerID equals worker.WorkerID
                             where wdt.DepartmentTypeID == departmentTypeID && worker.Status == true
                             select new WorkerDepartmentDto
                             {
                                 WorkerID = worker.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 DailyWorkingTime = worker.DailyWorkingTime,
                                 HourSalary = worker.HourSalary,
                                 StartTime = worker.StartTime,
                                 Status = worker.Status,
                                 DepartmentTypes = db.DepartmentTypes.Where(p => p.DepartmentTypeID == departmentTypeID).ToList(),

                             };
                return result.ToList();
            }
        }

        public List<WorkerDepartmentDto> GetByWorkerID(int workerID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from wdt in db.WorkerDepartmentTypes
                             join worker in db.Workers on
                             wdt.WorkerID equals worker.WorkerID
                             where worker.Status == true && wdt.WorkerID == workerID
                             select new WorkerDepartmentDto
                             {
                                 WorkerID = worker.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 DailyWorkingTime = worker.DailyWorkingTime,
                                 HourSalary = worker.HourSalary,
                                 StartTime = worker.StartTime,
                                 Status = worker.Status,
                                 DepartmentTypes = db.DepartmentTypes.Where(p => db.WorkerDepartmentTypes.Where(y => y.WorkerID == worker.WorkerID)
                                 .Select(x => x.DepartmentTypeID).Contains(p.DepartmentTypeID)).ToList(),
                             };
                return result.ToList();
            }
        }
    }
}
