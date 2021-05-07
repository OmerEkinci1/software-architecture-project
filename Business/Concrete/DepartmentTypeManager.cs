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
    public class DepartmentTypeManager : IDepartmentTypeService
    {
        private IDepartmentTypeDal _departmentTypeDal;

        public DepartmentTypeManager(IDepartmentTypeDal departmentTypeDal)
        {
            _departmentTypeDal = departmentTypeDal;
        }

        public IResult Add(DepartmentType departmentType)
        {
            _departmentTypeDal.Add(departmentType);
            return new SuccessResult(Messages.DepartmentAdded);
        }

        public IResult Delete(DepartmentType departmentType)
        {
            _departmentTypeDal.Delete(departmentType);
            return new SuccessResult(Messages.DepartmentDeleted);
        }

        public IDataResult<DepartmentType> Get(int departmentTypeID)
        {
            return new SuccessDataResult<DepartmentType>(_departmentTypeDal.Get(p => p.DepartmentTypeID == departmentTypeID));
        }

        public IDataResult<List<DepartmentType>> GetAll()
        {
            return new SuccessDataResult<List<DepartmentType>>(_departmentTypeDal.GetAll());
        }

        public IResult Update(DepartmentType departmentType)
        {
            _departmentTypeDal.Update(departmentType);
            return new SuccessResult(Messages.DepartmentUpdated);
        }
    }
}
