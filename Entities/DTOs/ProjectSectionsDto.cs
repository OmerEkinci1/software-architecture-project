using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectSectionsDto : IDto
    {
        public int ProjectSectionID { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public Byte DepartmentTypeID { get; set; }
        public string DepartmentTypeName { get; set; }
        public DateTime SectionProjectTime { get; set; }
        public DateTime RemainingSectionTime { get; set; }
        public Byte WorkerCount { get; set; }
    }
}
