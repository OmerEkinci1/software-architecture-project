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
    public class EfWorkerSalaryExperienceDal : EfEntityRepositoryBase<WorkerSalaryExperience, DatabaseContext>, IWorkerSalaryExperienceDal
    {
        public List<WorkerSalaryExperienceDto> GetAll()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from wse in db.WorkerSalaryExperiences
                             join department in db.DepartmentTypes on
                             wse.DepartmentTypeID equals department.DepartmentTypeID
                             select new WorkerSalaryExperienceDto
                             {
                                 WorkerSalaryExperienceID = wse.WorkerSalaryExperienceID,
                                 DepartmentTypeID = wse.DepartmentTypeID,
                                 DepartmentTypeName = department.DepartmentTypeName,
                                 Year = wse.Year,
                                 minHourSalary = wse.minHourSalary,
                                 maxHourSalary = wse.maxHourSalary,
                             };
                return result.ToList();

            }
        }

        public List<WorkerSalaryExperienceDto> GetByDepartmentTypeID(int departmentTypeID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from wse in db.WorkerSalaryExperiences
                             join department in db.DepartmentTypes on
                             wse.DepartmentTypeID equals department.DepartmentTypeID
                             where wse.DepartmentTypeID == departmentTypeID
                             select new WorkerSalaryExperienceDto
                             {
                                 WorkerSalaryExperienceID = wse.WorkerSalaryExperienceID,
                                 DepartmentTypeID = wse.DepartmentTypeID,
                                 DepartmentTypeName = department.DepartmentTypeName,
                                 Year = wse.Year,
                                 minHourSalary = wse.minHourSalary,
                                 maxHourSalary = wse.maxHourSalary,
                             };
                return result.ToList();

            }
        }
    }
}
