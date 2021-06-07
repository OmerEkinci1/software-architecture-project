using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProjectSectionDepartmentDal : IEntityRepository<ProjectSectionDepartment>
    {
        //List<ProjectSectionDepartmentDto> GetByProjectID(int projectID);
        List<ProjectSectionDepartmentDto> GetBySectionID(int sectionID);
        ProjectSectionDepartmentDto GetByID(int projectSectionDepartmentID);
        List<ProjectSectionDepartmentDto> GetAll();
        //List<ProjectSectionDepartmentDto> GetByUserID(int userID); //bu kısım EfProjectSection  için
    }
}
