using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IHRService
    {
        IResult Add(HR hr);
        IResult Update(HR hr);
        IResult Delete(HR hr);

        IDataResult<HR> Get(int hrID);
    }
}
