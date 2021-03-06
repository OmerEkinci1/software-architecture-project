using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectService
    {
        IResult Add(Project project);
        IResult Update(Project project);
        IResult Delete(int projectID);
        IDataResult<ProjectDetailDto> GetByID(int projectID);
        IDataResult<List<ProjectDetailDto>> GetAll();
        IDataResult<List<ProjectDetailDto>> GetProjectByUserID(int userID);



    }
}
