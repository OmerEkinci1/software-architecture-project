using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class HRManager : IHRService
    {
        private IHRDal _hRDal;

        public HRManager(IHRDal hRDal)
        {
            _hRDal = hRDal;
        }

        public IResult Add(HR hr)
        {
            _hRDal.Add(hr);
            return new SuccessResult(Messages.HRAdded);
        }

        public IResult Delete(HR hr)
        {
            _hRDal.Delete(hr);
            return new SuccessResult(Messages.HRDeleted);
        }

        public IDataResult<HR> Get(int hrID)
        {
            return new SuccessDataResult<HR>(_hRDal.Get(h => h.HrID == hrID));
        }

        public IResult Update(HR hr)
        {
            _hRDal.Update(hr);
            return new SuccessResult(Messages.HRUpdated);
        }
    }
}
