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
    public class EfProjectDal : EfEntityRepositoryBase<Project, DatabaseContext>, IProjectDal
    {
        public List<ProjectDetailDto> GetAll()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from project in db.Projects
                             join user in db.Users on
                             project.UserID equals user.UserID
                             where project.Status==true
                             select new ProjectDetailDto
                             {
                                 ProjectID = project.ProjectID,
                                 UserID = project.UserID,
                                 Name = user.Name,
                                 Surname = user.Surname,
                                 ProjectName = project.ProjectName,
                                 Subject = project.Subject,
                                 ProjectBudget = project.ProjectBudget,
                                 MinWorkerCount = project.MinWorkerCount,
                                 MaxWorkerCount = project.MaxWorkerCount,
                                 ActiveWorkerCount = project.ActiveWorkerCount,
                                 TotalDeclaredTime = project.TotalDeclaredTime,
                                 RemainingProjectTime = project.RemainingProjectTime,
                                 Status =project.Status
                             };
                return result.ToList();
            }
        }

        public ProjectDetailDto GetByID(int projectID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from project in db.Projects
                             join user in db.Users on
                             project.UserID equals user.UserID
                             where project.Status == true && project.ProjectID== projectID
                             select new ProjectDetailDto
                             {
                                 ProjectID = project.ProjectID,
                                 UserID = project.UserID,
                                 Name = user.Name,
                                 Surname = user.Surname,
                                 ProjectName = project.ProjectName,
                                 Subject = project.Subject,
                                 ProjectBudget = project.ProjectBudget,
                                 MinWorkerCount = project.MinWorkerCount,
                                 MaxWorkerCount = project.MaxWorkerCount,
                                 ActiveWorkerCount = project.ActiveWorkerCount,
                                 TotalDeclaredTime = project.TotalDeclaredTime,
                                 RemainingProjectTime = project.RemainingProjectTime,
                                 Status = project.Status
                             };
                return result.SingleOrDefault();
            }
        }

        public List<ProjectDetailDto> GetProjectByUserID(int userID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from project in db.Projects
                             join user in db.Users on
                             project.UserID equals user.UserID
                             where project.UserID == userID && project.Status == true
                             select new ProjectDetailDto
                             {
                                 ProjectID = project.ProjectID,
                                 UserID = project.UserID,
                                 Name = user.Name,
                                 Surname = user.Surname,
                                 ProjectName = project.ProjectName,
                                 Subject = project.Subject,
                                 ProjectBudget = project.ProjectBudget,
                                 MinWorkerCount = project.MinWorkerCount,
                                 MaxWorkerCount = project.MaxWorkerCount,
                                 ActiveWorkerCount = project.ActiveWorkerCount,
                                 TotalDeclaredTime = project.TotalDeclaredTime,
                                 RemainingProjectTime = project.RemainingProjectTime,
                                 Status = project.Status
                             };
                return result.ToList();
            }
        }





        //public List<ProjectDetailsForProjectWorkerDto> GetProjectDetailByProjectSectionDepartmentID(int projectSectionDepartmentID) //bir tane dönücek diğer project workerlar hepsi dto larında list olarak istediğinden bunuda list döndürmek durumundayız.
        //{
        //    using (DatabaseContext db = new DatabaseContext())
        //    {
        //        var result = from projectworker in db.ProjectWorkers
        //                     join psd in db.ProjectSectionDepartments on 
        //                     projectworker.ProjectSectionsDepartmentID equals psd.ProjectSectionsDepartmentID
        //                     join ps in db.ProjectSections on 
        //                     psd.ProjectSectionID equals ps.ProjectSectionID
        //                     join project in db.Projects on
        //                     ps.ProjectID equals project.ProjectID
        //                     join user in db.Users on 
        //                     project.UserID equals user.UserID
        //                     join worker in db.Workers on
        //                     projectworker.WorkerID equals worker.WorkerID
        //                     join department in db.DepartmentTypes on
        //                     psd.DepartmentTypeID equals department.DepartmentTypeID
        //                     where psd.ProjectSectionsDepartmentID== projectSectionDepartmentID
        //                     select new ProjectDetailsForProjectWorkerDto
        //                     {
        //                         ProjectID = project.ProjectID,                                 
        //                         ProjectName = project.ProjectName,
        //                         Subject = project.Subject,
        //                         ProjectBudget = project.ProjectBudget,
        //                         MinWorkerCount = project.MinWorkerCount,
        //                         MaxWorkerCount = project.MaxWorkerCount,
        //                         ActiveWorkerCount = project.ActiveWorkerCount,
        //                         TotalDeclaredTime = project.TotalDeclaredTime,
        //                         RemainigProjectTime = project.RemainigProjectTime,
        //                         Status = project.Status,
        //                         UserID = project.UserID,
        //                         ManagerName = user.Name,
        //                         ManagerSurname= user.Surname,
        //                         ProjectSectionID=ps.ProjectSectionID,
        //                         ProjectSectionName=ps.ProjectSectionName,
        //                         SectionProjectTime=ps.SectionProjectTime,
        //                         RemainingSectionTime=ps.RemainigSectionTime,
        //                         WorkerCount=ps.WorkerCount,
        //                         ProjectSectionDepartmentID=psd.ProjectSectionsDepartmentID,
        //                         DepartmentTypeID=psd.DepartmentTypeID,
        //                         DepartmentTypeName=department.DepartmentTypeName,                                 
        //                     };
        //        return result.ToList();
        //    }
        //}
    }
}
