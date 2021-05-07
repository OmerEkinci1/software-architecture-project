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
        public List<ProjectSectionsDto> GetAll()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from projectsection in db.ProjectSections
                             join project in db.Projects on
                             projectsection.ProjectID equals project.ProjectID
                             join departmentType in db.DepartmentTypes on
                             projectsection.DepartmentTypeID equals departmentType.DepartmentTypeID
                             select new ProjectSectionsDto
                             {
                                 ProjectSectionID = projectsection.ProjectSectionID,
                                 ProjectID = project.ProjectID,
                                 ProjectName = project.ProjectName,
                                 DepartmentTypeID = projectsection.DepartmentTypeID,
                                 DepartmentTypeName = departmentType.DepartmentTypeName,
                                 SectionProjectTime = projectsection.SectionProjectTime,
                                 RemainingSectionTime = projectsection.RemainigSectionTime,
                                 WorkerCount = projectsection.WorkerCount
                             };
                return result.ToList();
            }
        }

        public ProjectSectionsDto GetByProjectID(int projectID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from projectsection in db.ProjectSections
                             join project in db.Projects on
                             projectsection.ProjectID equals project.ProjectID
                             join departmentType in db.DepartmentTypes on
                             projectsection.DepartmentTypeID equals departmentType.DepartmentTypeID
                             where projectsection.ProjectID == projectID
                             select new ProjectSectionsDto
                             {
                                 ProjectSectionID = projectsection.ProjectSectionID,
                                 ProjectID = project.ProjectID,
                                 ProjectName = project.ProjectName,
                                 DepartmentTypeID = projectsection.DepartmentTypeID,
                                 DepartmentTypeName = departmentType.DepartmentTypeName,
                                 SectionProjectTime = projectsection.SectionProjectTime,
                                 RemainingSectionTime = projectsection.RemainigSectionTime,
                                 WorkerCount = projectsection.WorkerCount
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
