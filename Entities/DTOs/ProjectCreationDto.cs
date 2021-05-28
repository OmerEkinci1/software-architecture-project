using Core.Entites;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectCreationDto:IDto
    {
        public int UserID { get; set; }
        public string ProjectName { get; set; }
        public string Subject { get; set; }
        public decimal ProjectBudget { get; set; }
        public Byte MinWorkerCount { get; set; }
        public Byte MaxWorkerCount { get; set; }
        public decimal TotalDeclaredTime { get; set; }
        public List<ProjectSectionCreationDto> ProjectSections{ get; set; }

    }
}
