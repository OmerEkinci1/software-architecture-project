using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectService
    {
        IResult Add(Project project);
        IResult Update(Project project);
        IResult Delete(Project project);

        IDataResult<List<Project>> GetAll();
    }
}
