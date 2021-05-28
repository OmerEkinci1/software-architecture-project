using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserOperationClaimDto : IDto
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string OperationClaimName { get; set; }
    }
}
