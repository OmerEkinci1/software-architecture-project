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
    public class EfProjectSectionDal : EfEntityRepositoryBase<ProjectSection, DatabaseContext>, IProjectSectionDal
    {
        //public List<ProjectSectionDto> GetByUserID(int userID)
        //{
        //    using (DatabaseContext db = new DatabaseContext())
        //    {
        //        var result = from projectsection in db.ProjectSections
        //                     join project in db.Projects on
        //                     projectsection.ProjectID equals project.ProjectID
        //                     join user in db.Users on 
        //                     project.UserID equals user.UserID
        //                     where project.UserID== userID
        //                     select new ProjectSectionDto
        //                     {
        //                         ProjectSectionID = projectsection.ProjectSectionID,
        //                         ProjectSectionName = projectsection.ProjectSectionName,
        //                         ProjectID = project.ProjectID,
        //                         ProjectName = project.ProjectName,
        //                         SectionProjectTime = projectsection.SectionProjectTime,
        //                         RemainingSectionTime = projectsection.RemainigSectionTime,
        //                         WorkerCount = projectsection.WorkerCount,
        //                         ProjectSectionDepartmentDto = _projectSectionDepartmentDal.GetByProjectID(userID),
        //                     };
        //        return result.ToList();
        //    }
        //}
        public List<ProjectSectionDto> GetAll()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from projectsection in db.ProjectSections
                             join project in db.Projects on
                             projectsection.ProjectID equals project.ProjectID
                             where projectsection.Status==true
                             select new ProjectSectionDto
                             {
                                 ProjectSectionID = projectsection.ProjectSectionID,
                                 ProjectSectionName = projectsection.ProjectSectionName,
                                 ProjectID = project.ProjectID,
                                 ProjectName = project.ProjectName,
                                 SectionProjectTime = projectsection.SectionProjectTime,
                                 RemainingSectionTime = projectsection.RemainingSectionTime,
                                 WorkerCount = projectsection.WorkerCount,
                                 Status= projectsection.Status

                             };
                return result.ToList();
            }
        }
    }
}
