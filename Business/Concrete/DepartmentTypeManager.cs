using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
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
            IResult result = BusinessRules.Run(CheckIfDepartmentAlreadyExist(departmentType));
            if (result!=null)
            {
                return result;
            }
            _departmentTypeDal.Add(departmentType);
            return new SuccessResult(Messages.DepartmentAdded);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<DepartmentType>> GetAll()
        {
            return new SuccessDataResult<List<DepartmentType>>(_departmentTypeDal.GetAll());
        }

        public IResult Update(DepartmentType departmentType)
        {
            IResult result = BusinessRules.Run(CheckIfDepartmentAlreadyExist(departmentType));
            if (result != null)
            {
                return result;
            }
            _departmentTypeDal.Update(departmentType);
            return new SuccessResult(Messages.DepartmentUpdated);
        }

        private IResult CheckIfDepartmentAlreadyExist(DepartmentType departmentType)
        {
            var result = _departmentTypeDal.Get(d => d.DepartmentTypeName == departmentType.DepartmentTypeName);
            if (result != null)
            {
                if (result.DepartmentTypeID!=departmentType.DepartmentTypeID)
                {
                    return new ErrorResult(Messages.UserAlreadyHaveDepartment);
                }
            }
            return new SuccessResult();
        }
    }
}
