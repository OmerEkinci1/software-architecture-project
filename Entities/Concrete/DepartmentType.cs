using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class DepartmentType : IEntity
    {
        public Byte DepartmentID { get; set; }
        public string DepartmentTypeName { get; set; }
    }
}
