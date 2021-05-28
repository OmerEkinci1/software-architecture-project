using Core.Entites;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class ProjectSectionCreationDto:IDto
    {
        public string ProjectSectionName { get; set; }
        public decimal SectionProjectTime { get; set; }
        public List<ProjectSectionDepartment> ProjectSectionDepartment{ get; set; }
    }
}
