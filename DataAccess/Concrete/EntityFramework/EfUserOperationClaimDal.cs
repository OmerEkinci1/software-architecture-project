using Core.DataAccess.EntityFramework;
using Core.Entites.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, DatabaseContext>, IUserOperationClaimDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (DatabaseContext db= new DatabaseContext())
            {
                var result = from u in db.Users
                             join uop in db.UserOperationClaims on
                             u.UserID equals uop.UserID
                             select new OperationClaim
                             {             
                                 OperationClaimID=uop.OperationClaimID,
                             };
                return result.ToList();
            }
        }

        public List<UserOperationClaimDto> GetAllUserOperationClaim()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = from us in db.Users
                             join uop in db.UserOperationClaims on
                             us.UserID equals uop.UserID
                             join o in db.OperationClaims on
                             uop.OperationClaimID equals o.OperationClaimID
                             select new UserOperationClaimDto
                             {
                                 UserID = us.UserID,
                                 OperationClaimID = o.OperationClaimID,
                                 UserOperationClaimID = uop.UserOperationClaimID,
                                 UserName = us.Name,
                                 UserSurname = us.Surname,
                                 OperationClaimName = o.OperationClaimName,

                             };
                return result.ToList();
            }
        }
    }
}
