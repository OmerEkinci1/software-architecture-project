using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ProjectWorker : IEntity
    {
        public int ProjectWorkerID { get; set; }
        public int WorkerID { get; set; }
        public int ProjectSectionDepartmentID { get; set; }
        public bool Status { get; set; }
    }
}
