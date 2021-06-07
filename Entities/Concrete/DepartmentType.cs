using Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class DepartmentType : IEntity
    {   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Byte DepartmentTypeID { get; set; }
        public string DepartmentTypeName { get; set; }
    }
}
