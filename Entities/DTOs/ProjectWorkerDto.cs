using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectWorkerDto : IDto
    {
        public int ProjectWorkerID { get; set; }
        public int WorkerID { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public int ProjectSectionDepartmentID { get; set; }
        public bool Status { get; set; }
        //public List<ProjectDetailDto> ProjectDetail { get; set; }
        //public List<ProjectDetailsForProjectWorkerDto> ProjectDetailForProjectWorker { get; set; }

    }
}
