using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Concrete
{
    public class User : IEntity
    {
        public int UserID { get; set; }
        public Byte DepartmentTypeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}
