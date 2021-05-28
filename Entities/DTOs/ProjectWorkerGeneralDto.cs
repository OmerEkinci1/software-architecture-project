using Core.Entites;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectWorkerGeneralDto:IDto
    {
        public ProjectDetailDto projectDetail { get; set; }
        public ProjectSection projectSection { get; set; }
        public ProjectSectionDepartmentDto projectSectionDepartments { get; set; }
        public ProjectWorkerDto projectWorkerDto { get; set; }

    }
}
