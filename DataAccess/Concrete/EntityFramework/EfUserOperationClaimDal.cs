using Core.DataAccess.EntityFramework;
using Core.Entites.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, DatabaseContext>, IUserOperationClaimDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new DatabaseContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.OperationClaimID equals userOperationClaim.OperationClaimID
                             where userOperationClaim.UserID == user.UserID
                             select new OperationClaim { OperationClaimID = operationClaim.OperationClaimID, OperationClaimName = operationClaim.OperationClaimName };
                return result.ToList();

            }
        }
    }
}
