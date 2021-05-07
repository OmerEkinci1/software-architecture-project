using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectWorkersDto : IDto
    {
        public int ProjectWorkerID { get; set; }
        public int WorkerID { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public Byte DepartmentTypeID { get; set; } // worker hangi departmana ait onun bilgisi gerekli.
        public string DepartmentTypeName { get; set; }      
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Subject { get; set; }

    }
}
