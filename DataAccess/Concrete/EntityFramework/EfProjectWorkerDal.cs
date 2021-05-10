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
    public class EfProjectWorkerDal : EfEntityRepositoryBase<ProjectWorker, DatabaseContext>, IProjectWorkerDal
    {
        public List<ProjectWorkerDto> GetAll()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from projectworkers in db.ProjectWorkers
                             join worker in db.Workers on
                             projectworkers.WorkerID equals worker.WorkerID
                             where projectworkers.Status==true
                             select new ProjectWorkerDto
                             {
                                 ProjectWorkerID = projectworkers.ProjectWorkerID,
                                 WorkerID = worker.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 ProjectSectionDepartmentID= projectworkers.ProjectSectionDepartmentID,
                                 Status= projectworkers.Status
                             };
                 
                return result.ToList(); //ProjectSectionDepartmentID     //   ProjectSectionDepartmentID     //  ProjectSectionDepartmentID

            }
        }

        public ProjectWorkerDto GetByProjectSectionDepartmentID(int projectSectionDepartmentID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from projectworkers in db.ProjectWorkers
                             join worker in db.Workers on
                             projectworkers.WorkerID equals worker.WorkerID
                             join projectsectiondepartment in db.ProjectSectionDepartments on
                             projectworkers.ProjectSectionDepartmentID equals projectsectiondepartment.ProjectSectionDepartmentID
                             join projectsection in db.ProjectSections on
                             projectsectiondepartment.ProjectSectionID equals projectsection.ProjectSectionID
                             join project in db.Projects on
                             projectsection.ProjectID equals project.ProjectID  
                             join user in db.Users on
                             project.UserID equals user.UserID
                             where projectworkers.ProjectSectionDepartmentID == projectSectionDepartmentID && projectworkers.Status == true
                             select new ProjectWorkerDto
                             {
                                 ProjectWorkerID = projectworkers.ProjectWorkerID,
                                 WorkerID = worker.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 ProjectSectionDepartmentID = projectworkers.ProjectSectionDepartmentID,
                                 Status = projectworkers.Status
                                 //ProjectDetailForProjectWorker=_projectDal.GetProjectDetailByProjectSectionDepartmentID(projectSectionDepartmentID),
                                 //ProjectDetail=null
                             };
                return result.SingleOrDefault();

            }
        }

        public List<ProjectWorkerDto> GetByWorkerID(int workerID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from projectworkers in db.ProjectWorkers
                             join worker in db.Workers on
                             projectworkers.WorkerID equals worker.WorkerID
                             join projectsectiondepartment in db.ProjectSectionDepartments on
                             projectworkers.ProjectSectionDepartmentID equals projectsectiondepartment.ProjectSectionDepartmentID
                             join projectsection in db.ProjectSections on
                             projectsectiondepartment.ProjectSectionID equals projectsection.ProjectSectionID
                             join project in db.Projects on
                             projectsection.ProjectID equals project.ProjectID
                             join user in db.Users on
                             project.UserID equals user.UserID
                             where projectworkers.WorkerID == workerID && projectworkers.Status == true
                             select new ProjectWorkerDto
                             {
                                 ProjectWorkerID = projectworkers.ProjectWorkerID,
                                 WorkerID = worker.WorkerID,
                                 WorkerName = worker.WorkerName,
                                 WorkerSurname = worker.WorkerSurname,
                                 ProjectSectionDepartmentID = projectworkers.ProjectSectionDepartmentID,
                                 Status = projectworkers.Status
                                 //ProjectDetail = _projectDal.GetProjectByUserID(user.UserID),
                                 //ProjectDetailForProjectWorker=null
                             };
                return result.ToList();

            }
        }
    }
}
