using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ProjectManager : IEntity
    {
        public int ManagerID { get; set; }
        public Byte DepartmentID { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
    }
}
