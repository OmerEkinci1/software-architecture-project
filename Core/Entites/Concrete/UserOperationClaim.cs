using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int UserOperationClaimID { get; set; }
        public int UserID { get; set; }
        public int OperationClaimID { get; set; }
    }
}
