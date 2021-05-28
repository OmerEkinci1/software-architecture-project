using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectSectionDepartmentDto:IDto
    {
        public int ProjectSectionDepartmentID { get; set; }
        public int ProjectSectionID { get; set; }
        public string ProjectSectionName { get; set; }
        public Byte DepartmentTypeID { get; set; }
        public string DepartmentTypeName { get; set; }
    }
}
