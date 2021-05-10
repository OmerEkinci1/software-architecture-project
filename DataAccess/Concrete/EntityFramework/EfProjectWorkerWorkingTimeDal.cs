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
        public List<ProjectWorkerWorkingTimeDto> GetByProjectWorkerID(int projectWorkerID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from pwwt in db.ProjectWorkerWorkingTimes
                             join projectworker in db.ProjectWorkers on
                             pwwt.ProjectWorkerID equals projectworker.ProjectWorkerID
                             join worker in db.Workers on
                             projectworker.WorkerID equals worker.WorkerID
                             join projectsectiondepartment in db.ProjectSectionDepartments on
                             projectworker.ProjectSectionDepartmentID equals projectsectiondepartment.ProjectSectionDepartmentID
                             join projectsection in db.ProjectSections on
                            projectsectiondepartment.ProjectSectionID equals projectsection.ProjectSectionID
                             join project in db.Projects on
                             projectsection.ProjectID equals project.ProjectID
                             join department in db.DepartmentTypes on
                             projectsectiondepartment.DepartmentTypeID equals department.DepartmentTypeID
                             where projectworker.ProjectWorkerID == projectWorkerID
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
                                 DepartmentTypeID= projectsectiondepartment.DepartmentTypeID,
                                 DepartmentTypeName=department.DepartmentTypeName,
                                 ProjectSectionDepartmentID=projectworker.ProjectSectionDepartmentID,
                                 ProjectSectionID= projectsectiondepartment.ProjectSectionID,
                                 ProjectSectionName=projectsection.ProjectSectionName,
                                 ProjectID = project.ProjectID,
                                 ProjectName = project.ProjectName,

                             };
                return result.ToList();
            }
        }
    }
}
