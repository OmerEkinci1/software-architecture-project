using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectGeneralDto:IDto
    {
        public ProjectDetailDto ProjectDetailDto { get; set; }
        public List<ProjectSectionKeepListDepartmentDto> projectSectionKeepListDepartments { get; set; }
    }
}
