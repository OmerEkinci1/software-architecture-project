using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectDetailsForProjectWorkerDto:IDto
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Subject { get; set; }
        public decimal ProjectBudget { get; set; }
        public Byte MinWorkerCount { get; set; }
        public Byte MaxWorkerCount { get; set; }
        public Byte ActiveWorkerCount { get; set; }
        public DateTime TotalDeclaredTime { get; set; }
        public DateTime RemainigProjectTime { get; set; }
        public byte Status { get; set; }
        public int UserID { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
        public int ProjectSectionID { get; set; }
        public string ProjectSectionName { get; set; }
        public DateTime SectionProjectTime { get; set; }
        public DateTime RemainingSectionTime { get; set; }
        public Byte WorkerCount { get; set; }
        public int ProjectSectionDepartmentID { get; set; }
        public Byte DepartmentTypeID { get; set; }
        public string DepartmentTypeName { get; set; }

    }
}
