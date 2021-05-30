using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserOperationClaimDto : IDto
    {
        public int UserOperationClaimID { get; set; }
        public int UserID { get; set; }
        public int OperationClaimID { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string OperationClaimName { get; set; }


    }
}
