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
        public List<WorkerSalaryDto> GetAll()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from salary in db.Salaries
                             join worker in db.Workers on
                             salary.WorkerID equals worker.WorkerID
                             join user in db.Users on
                             salary.UserID equals user.UserID
                             select new WorkerSalaryDto
                             {
                                 WorkerID = salary.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 WorkerStatus=worker.Status,
                                 SalaryID = salary.SalaryID,
                                 SalaryAmount = salary.SalaryAmount,
                                 SalaryDate = salary.SalaryDate,
                                 DailyWorkingTime = worker.DailyWorkingTime,
                                 HourSalary = worker.HourSalary,
                                 StartDate = worker.StartTime,
                                 UserID = user.UserID,
                                 Name = user.Name,
                                 Surname = user.Surname
                             };
                return result.ToList();

            }

        }

        public List<WorkerSalaryDto> GetByUserID(int userID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from salary in db.Salaries
                             join worker in db.Workers on
                             salary.WorkerID equals worker.WorkerID
                             join user in db.Users on
                             salary.UserID equals user.UserID
                             where user.UserID == userID && worker.Status == true
                             select new WorkerSalaryDto
                             {
                                 WorkerID = salary.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 WorkerStatus = worker.Status,
                                 SalaryID = salary.SalaryID,
                                 SalaryAmount = salary.SalaryAmount,
                                 SalaryDate = salary.SalaryDate,
                                 DailyWorkingTime = worker.DailyWorkingTime,
                                 HourSalary = worker.HourSalary,
                                 StartDate = worker.StartTime,
                                 UserID = user.UserID,
                                 Name = user.Name,
                                 Surname = user.Surname
                             };
                return result.ToList();

            }
        }

        public WorkerSalaryDto GetWorkerID(int workerID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from salary in db.Salaries
                             join worker in db.Workers on
                             salary.WorkerID equals worker.WorkerID
                             join user in db.Users on
                             salary.UserID equals user.UserID
                             where worker.WorkerID == workerID && worker.Status == true
                             orderby salary.SalaryDate descending 
                             select new WorkerSalaryDto
                             {
                                 WorkerID = salary.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 WorkerStatus = worker.Status,
                                 SalaryID = salary.SalaryID,
                                 SalaryAmount = salary.SalaryAmount,
                                 SalaryDate = salary.SalaryDate,
                                 DailyWorkingTime = worker.DailyWorkingTime,
                                 HourSalary = worker.HourSalary,
                                 StartDate = worker.StartTime,
                                 UserID = user.UserID,
                                 Name = user.Name,
                                 Surname = user.Surname
                             };
                return result.FirstOrDefault();

            }
        }

    }
}
