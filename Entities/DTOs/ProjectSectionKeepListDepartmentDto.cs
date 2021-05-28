using Core.Entites;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectSectionKeepListDepartmentDto:IDto
    {
        public ProjectSection projectSection{ get; set; }
        public List<ProjectSectionDepartmentDto>projectSectionDepartmentDtos { get; set; }
    }
}
