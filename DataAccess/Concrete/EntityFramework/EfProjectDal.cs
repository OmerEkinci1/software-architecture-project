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
                             join manager in db.ProjectManagers on
                             project.ManagerID equals manager.ManagerID
                             select new ProjectDetailDto
                             {
                                 ProjectID = project.ProjectID,
                                 ManagerID = project.ManagerID,
                                 ManagerName = manager.ManagerName,
                                 ManagerSurname = manager.ManagerSurname,
                                 ProjectName = project.ProjectName,
                                 Subject = project.Subject,
                                 ProjectBudget = project.ProjectBudget,
                                 MinWorkerCount = project.MinWorkerCount,
                                 MaxWorkerCount = project.MaxWorkerCount,
                                 ActiveWorkerCount = project.ActiveWorkerCount,
                                 TotalDeclaredTime = project.TotalDeclaredTime,
                                 RemainigProjectTime = project.RemainigProjectTime
                             };
                return result.ToList();
            }
        }

        public ProjectDetailDto GetProjectByManagerID(int managerID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from project in db.Projects
                             join manager in db.ProjectManagers on
                             project.ManagerID equals manager.ManagerID
                             where project.ManagerID == managerID
                             select new ProjectDetailDto
                             {
                                 ProjectID = project.ProjectID,
                                 ManagerID = project.ManagerID,
                                 ManagerName = manager.ManagerName,
                                 ManagerSurname = manager.ManagerSurname,
                                 ProjectName = project.ProjectName,
                                 Subject = project.Subject,
                                 ProjectBudget = project.ProjectBudget,
                                 MinWorkerCount = project.MinWorkerCount,
                                 MaxWorkerCount = project.MaxWorkerCount,
                                 ActiveWorkerCount = project.ActiveWorkerCount,
                                 TotalDeclaredTime = project.TotalDeclaredTime,
                                 RemainigProjectTime = project.RemainigProjectTime
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
