using Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class WorkerDepartmentType:IEntity
    {
        [Key]
        public int WorkerID { get; set; }
        [Key]
        public Byte DepartmentTypeID { get; set; }

    }
}
