using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserTokenDto : IDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int UserID { get; set; }
    }
}
