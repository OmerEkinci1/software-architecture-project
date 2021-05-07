using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Concrete
{
    public class OperationClaim : IEntity
    {
        public int OperationClaimID { get; set; }
        public string OperationClaimName { get; set; }
    }
}
