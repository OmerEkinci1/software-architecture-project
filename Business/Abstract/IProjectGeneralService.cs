using Core.Entites.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectGeneralService
    {
        IResult Add(ProjectCreationDto projectCreationDto);
        IResult Delete(int projectID);
        IDataResult<ProjectGeneralDto> GetProjectByProjectID(int projectID);

    }
}
