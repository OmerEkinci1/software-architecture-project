using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ProjectSection : IEntity
    {
        public int ProjectSectionID { get; set; }
        public int ProjectID { get; set; }
        public Byte DepartmentTypeID { get; set; }
        public DateTime SectionProjectTime { get; set; }
        public DateTime RemainigSectionTime { get; set; }
        public Byte WorkerCount { get; set; }
    }
}
