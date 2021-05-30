using Business.Abstract;
using Business.Constants;
using Core.Entites.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim userOperationClaim)
        {
            IResult result = BusinessRules.Run(CheckUserHasOperationClaim(userOperationClaim));
            if (result!=null)
            {
                return result;
            }
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }



        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimDeleted);
        }

        public IDataResult<List<UserOperationClaimDto>> GetAllUserClaims()
        {
            return new SuccessDataResult<List<UserOperationClaimDto>>(_userOperationClaimDal.GetAllUserOperationClaim());
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userOperationClaimDal.GetClaims(user));
        }

        public IResult Update(UserOperationClaim userOperationClaim)
        {
            IResult result = BusinessRules.Run(CheckUserHasOperationClaim(userOperationClaim));
            if (result!=null)
            {
                return result;
            }
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimUpdated);
        }

        private IResult CheckUserHasOperationClaim(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimDal.Get(o => o.OperationClaimID == userOperationClaim.OperationClaimID);
            if (result != null)
            {
                if (result.UserOperationClaimID != userOperationClaim.UserOperationClaimID)
                {
                    return new ErrorResult(Messages.UserHasAlreadyOperationClaim);
                }

            }
            return new SuccessResult();

        }
    }
}
