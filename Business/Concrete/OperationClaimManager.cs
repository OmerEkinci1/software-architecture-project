using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Entites.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IResult Add(OperationClaim operationClaim)
        {
            IResult result = BusinessRules.Run(CheckIfOperationClaimAlreadyExist(operationClaim));
            if (result!=null)
            {
                return result;
            }
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.OperationClaimAdded);
        }

        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult(Messages.OperationClaimDeleted);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<OperationClaim>> GetAll()
        {            
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll());
        }

        public IResult Update(OperationClaim operationClaim)
        {
            IResult result = BusinessRules.Run(CheckIfOperationClaimAlreadyExist(operationClaim));
            if (result != null)
            {
                return result;
            }
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult(Messages.OperationClaimUpdated);
        }

        private IResult CheckIfOperationClaimAlreadyExist(OperationClaim operationClaim)
        {
            var result = _operationClaimDal.Get(o=>o.OperationClaimName==operationClaim.OperationClaimName);
            if (result != null)
            {
                if (result.OperationClaimID!=operationClaim.OperationClaimID)
                {
                    return new ErrorResult(Messages.OperationClaimAlreadyExist);
                }
                
            }
            return new SuccessResult();


        }
    }
}
