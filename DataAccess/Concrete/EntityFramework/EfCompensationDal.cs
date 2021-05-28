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
                             join user in db.Users on
                             compensation.UserID equals user.UserID
                             where worker.Status== false
                             orderby compensation.CompensationDate descending
                             select new WorkerCompensationDto
                             {
                                 WorkerID = compensation.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 CompensationID = compensation.CompensationID,
                                 CompensationAmount = compensation.CompensationAmount,
                                 CompensationDate = compensation.CompensationDate,
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

        public List<WorkerCompensationDto> GetByUserID(int userID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from compensation in db.Compensations
                             join worker in db.Workers on
                             compensation.WorkerID equals worker.WorkerID
                             join user in db.Users on
                            compensation.UserID equals user.UserID
                             orderby compensation.CompensationDate descending
                             where compensation.UserID == userID && worker.Status == false
                             select new WorkerCompensationDto
                             {
                                 WorkerID = compensation.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 CompensationID = compensation.CompensationID,
                                 CompensationAmount = compensation.CompensationAmount,
                                 CompensationDate = compensation.CompensationDate,
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

        public WorkerCompensationDto GetByWorkerID(int workerID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from compensation in db.Compensations
                             join worker in db.Workers on
                             compensation.WorkerID equals worker.WorkerID
                             join user in db.Users on
                            compensation.UserID equals user.UserID
                             orderby compensation.CompensationDate descending
                             where compensation.WorkerID == workerID && worker.Status == false
                             select new WorkerCompensationDto
                             {
                                 WorkerID = compensation.WorkerID,                                 
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 CompensationID = compensation.CompensationID,
                                 CompensationAmount = compensation.CompensationAmount,
                                 CompensationDate = compensation.CompensationDate,
                                 DailyWorkingTime = worker.DailyWorkingTime,
                                 HourSalary = worker.HourSalary,
                                 StartDate = worker.StartTime,
                                 UserID = user.UserID,
                                 Name = user.Name,
                                 Surname = user.Surname
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
