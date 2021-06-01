using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectSectionDto:IDto
    {
        public int ProjectSectionID { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectSectionName { get; set; }
        public decimal SectionProjectTime { get; set; }
        public decimal RemainingSectionTime { get; set; }
        public Byte WorkerCount { get; set; }
        public bool Status { get; set; }
    }
}
