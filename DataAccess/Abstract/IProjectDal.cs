using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProjectDal : IEntityRepository<Project>
    {
        List<ProjectDetailDto> GetAll();
        List<ProjectDetailDto> GetProjectByUserID(int userID);
        ProjectDetailDto GetByID(int projectID);
        //List<ProjectDetailsForProjectWorkerDto> GetProjectDetailByProjectSectionDepartmentID(int projectSectionDepartmentID);
    }
}
