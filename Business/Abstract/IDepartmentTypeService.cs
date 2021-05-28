using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDepartmentTypeService
    {
        IResult Add(DepartmentType departmentType);
        IResult Update(DepartmentType departmentType);
        IDataResult<List<DepartmentType>> GetAll();
    }
}
