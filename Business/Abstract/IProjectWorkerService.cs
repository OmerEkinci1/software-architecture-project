using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectWorkerService
    {
        IResult Add(ProjectWorkersDto projectWorkersDto);
        IResult Delete(ProjectWorkersDto projectWorkersDto);
        IResult Update(ProjectWorkersDto projectWorkersDto);

        IDataResult<List<ProjectWorkersDto>> GetAll();
        IDataResult<ProjectWorkersDto> Get(int args);
    }
}
