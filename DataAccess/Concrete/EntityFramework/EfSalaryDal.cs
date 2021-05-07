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
    public class EfSalaryDal : EfEntityRepositoryBase<Salary, DatabaseContext>, ISalaryDal
    {
        public List<WorkerSalaryDto> GetWorkerSalary(int workerID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from salary in db.Salaries
                             join worker in db.Workers on
                             salary.WorkerID equals worker.WorkerID
                             join department in db.DepartmentTypes on
                             worker.DepartmentTypeID equals department.DepartmentTypeID
                             where salary.WorkerID == workerID
                             select new WorkerSalaryDto
                             {
                                 WorkerID = salary.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 DepartmentTypeID = worker.DepartmentTypeID,
                                 DepartmentTypeName = department.DepartmentTypeName,
                                 SalaryID = salary.SalaryID,
                                 SalaryAmount = salary.SalaryAmount,
                                 SalaryDate = salary.SalaryDate,
                                 DailyWorkingTime = worker.DailyWorkingTime,
                                 HourSalary = worker.HourSalary,
                                 StartDate = worker.StartTime
                             };
                return result.ToList();
             }
        }
    }
}
