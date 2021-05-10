using Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class ProjectSectionDepartment:IEntity
    {
        [Key]
        public int ProjectSectionDepartmentID { get; set; }
        public int ProjectSectionID { get; set; }
        public Byte DepartmentTypeID { get; set; }
        public bool Status { get; set; }
    }
}
