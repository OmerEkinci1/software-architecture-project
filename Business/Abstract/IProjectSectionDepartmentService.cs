using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectSectionDepartmentService
    {
        IResult Add(ProjectSectionDepartment projectSectionDepartment);
        IResult Update(ProjectSectionDepartment projectSectionDepartment);
        IResult Delete(ProjectSectionDepartment projectSectionDepartment);
        //IDataResult<List<ProjectSectionDepartmentDto>> GetByProjectID(int projectID);
        IDataResult<List<ProjectSectionDepartmentDto>> GetBySectionID(int sectionID);
        IDataResult<List<ProjectSectionDepartmentDto>> GetAll();
        IDataResult<ProjectSectionDepartmentDto> GetByID(int projectSectionDepartmentID);
        //IDataResult<List<ProjectSectionDepartmentDto>> GetByUserID(int userID);


    }
}
