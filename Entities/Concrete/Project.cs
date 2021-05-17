using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Project : IEntity
    {
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public string ProjectName { get; set; }
        public string Subject { get; set; }
        public decimal ProjectBudget { get; set; }
        public Byte MinWorkerCount { get; set; }
        public Byte MaxWorkerCount { get; set; }
        public Byte ActiveWorkerCount { get; set; }
        public decimal TotalDeclaredTime { get; set; }
        public decimal RemainingProjectTime { get; set; }
        public bool Status { get; set; }
    }
}
