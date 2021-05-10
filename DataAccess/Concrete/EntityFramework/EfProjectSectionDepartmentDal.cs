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
    public class EfProjectSectionDepartmentDal : EfEntityRepositoryBase<ProjectSectionDepartment, DatabaseContext>, IProjectSectionDepartmentDal
    {
        //public List<ProjectSectionDepartmentDto> GetByUserID(int userID)
        //{
        //    using (DatabaseContext db = new DatabaseContext())
        //    {
        //        var result = from psd in db.ProjectSectionDepartments
        //                     join dep in db.DepartmentTypes on
        //                     psd.DepartmentTypeID equals dep.DepartmentTypeID
        //                     join ps in db.ProjectSections on
        //                     psd.ProjectSectionID equals ps.ProjectSectionID
        //                     join project in db.Projects on
        //                     ps.ProjectID equals project.ProjectID
        //                     where project.UserID == userID
        //                     select new ProjectSectionDepartmentDto
        //                     {
        //                         ProjectSectionDepartmentID = psd.ProjectSectionsDepartmentID,
        //                         ProjectSectionID = psd.ProjectSectionID,
        //                         ProjectSectionName=ps.ProjectSectionName,
        //                         DepartmentTypeID=psd.DepartmentTypeID,
        //                         DepartmentTypeName=dep.DepartmentTypeName

        //                     };

        //        return result.ToList();
        //    }
        //}

        public ProjectSectionDepartmentDto GetByID(int projectSectionDepartmentID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from psd in db.ProjectSectionDepartments
                             join dep in db.DepartmentTypes on
                             psd.DepartmentTypeID equals dep.DepartmentTypeID                            
                             where psd.ProjectSectionDepartmentID == projectSectionDepartmentID && psd.Status == true
                             select new ProjectSectionDepartmentDto
                             {
                                 ProjectSectionDepartmentID = psd.ProjectSectionDepartmentID,
                                 ProjectSectionID = psd.ProjectSectionID,
                                 DepartmentTypeID = psd.DepartmentTypeID,
                                 DepartmentTypeName = dep.DepartmentTypeName
                             };

                return result.SingleOrDefault();
            }
        }

        public List<ProjectSectionDepartmentDto> GetBySectionID(int sectionID)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from psd in db.ProjectSectionDepartments
                             join dep in db.DepartmentTypes on
                             psd.DepartmentTypeID equals dep.DepartmentTypeID
                             join ps in db.ProjectSections on
                             psd.ProjectSectionID equals ps.ProjectSectionID
                             join project in db.Projects on
                             ps.ProjectID equals project.ProjectID
                             where psd.ProjectSectionID==sectionID && psd.Status==true
                             select new ProjectSectionDepartmentDto
                             {
                                 ProjectSectionDepartmentID = psd.ProjectSectionDepartmentID,
                                 ProjectSectionID = psd.ProjectSectionID,
                                 ProjectSectionName = ps.ProjectSectionName,
                                 DepartmentTypeID = psd.DepartmentTypeID,
                                 DepartmentTypeName = dep.DepartmentTypeName

                             };

                return result.ToList();
            }
        }

        //public List<ProjectSectionDepartmentDto> GetByProjectID(int projectID)
        //{
        //    using (DatabaseContext db = new DatabaseContext())
        //    {
        //        var result = from psd in db.ProjectSectionDepartments
        //                     join dep in db.DepartmentTypes on
        //                     psd.DepartmentTypeID equals dep.DepartmentTypeID
        //                     join ps in db.ProjectSections on
        //                     psd.ProjectSectionID equals ps.ProjectSectionID                            
        //                     where ps.ProjectID == projectID
        //                     select new ProjectSectionDepartmentDto
        //                     {
        //                         ProjectSectionDepartmentID = psd.ProjectSectionsDepartmentID,
        //                         ProjectSectionID = psd.ProjectSectionID,
        //                         ProjectSectionName = ps.ProjectSectionName,
        //                         DepartmentTypeID = psd.DepartmentTypeID,
        //                         DepartmentTypeName = dep.DepartmentTypeName

        //                     };

        //        return result.ToList();
        //    }
        //}
    }
}
