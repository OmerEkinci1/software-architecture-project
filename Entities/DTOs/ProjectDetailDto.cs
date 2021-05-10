using Core.Entites;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectDetailDto : IDto
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Subject { get; set; }
        public decimal ProjectBudget { get; set; }
        public Byte MinWorkerCount { get; set; }
        public Byte MaxWorkerCount { get; set; }
        public Byte ActiveWorkerCount { get; set; }
        public DateTime TotalDeclaredTime { get; set; }
        public DateTime RemainingProjectTime { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Status { get; set; }
    }
}
