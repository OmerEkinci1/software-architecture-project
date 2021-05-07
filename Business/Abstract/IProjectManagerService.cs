using Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectManagerService
    {
        IResult Add(ProjectManager projectManager);
        IResult Update(ProjectManager projectManager);
        IResult Delete(ProjectManager projectManager);

        IDataResult<ProjectManager> Get(int managerID);
        //IDataResult<List<ProjectDetailDto>> GetByProjectManagerID(int managerID);
    }
}
