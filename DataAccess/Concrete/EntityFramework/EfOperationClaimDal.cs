using Core.DataAccess.EntityFramework;
using Core.Entites.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimDal: EfEntityRepositoryBase<OperationClaim, DatabaseContext>, IOperationClaimDal
    {
    }
}
