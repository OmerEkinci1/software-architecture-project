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
    public class EfCompensationDal : EfEntityRepositoryBase<Compensation, DatabaseContext>, ICompensationDal
    {
        public List<WorkerCompensationDto> GetAll()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from compensation in db.Compensations
                             join worker in db.Workers on
                             compensation.WorkerID equals worker.WorkerID
                             join department in db.DepartmentTypes on
                             worker.DepartmentTypeID equals department.DepartmentTypeID
                             orderby compensation.CompensationDate ascending
                             select new WorkerCompensationDto
                             {
                                 WorkerID = compensation.WorkerID,
                                 DepartmentTypeID = worker.DepartmentTypeID,
                                 DepartmentTypeName = department.DepartmentTypeName,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 CompensationID = compensation.CompensationID,
                                 CompensationAmount = compensation.CompensationAmount,
                                 CompensationDate = compensation.CompensationDate,
                                 DailyWorkingTime = worker.DailyWorkingTime,
                                 HourSalary = worker.HourSalary,
                                 StartDate = worker.StartTime,
                             };
                return result.ToList();
            }
        }

        public WorkerCompensationDto GetWorkerCompensation(int workerID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from compensation in db.Compensations
                             join worker in db.Workers on
                             compensation.WorkerID equals worker.WorkerID
                             join department in db.DepartmentTypes on
                             worker.DepartmentTypeID equals department.DepartmentTypeID
                             orderby compensation.CompensationDate ascending
                             where compensation.WorkerID == workerID
                             select new WorkerCompensationDto
                             {
                                 WorkerID = compensation.WorkerID,
                                 DepartmentTypeID = worker.DepartmentTypeID,
                                 DepartmentTypeName = department.DepartmentTypeName,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 CompensationID = compensation.CompensationID,
                                 CompensationAmount = compensation.CompensationAmount,
                                 CompensationDate = compensation.CompensationDate,
                                 DailyWorkingTime = worker.DailyWorkingTime,
                                 HourSalary = worker.HourSalary,
                                 StartDate = worker.StartTime,
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
