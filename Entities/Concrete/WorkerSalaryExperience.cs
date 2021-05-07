using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class WorkerSalaryExperience : IEntity
    {
        public int WorkerSalaryExperienceID { get; set; }
        public Byte DepartmentTypeID { get; set; }
        public Byte Year { get; set; }
        public decimal minHourSalary { get; set; }
        public decimal maxHourSalary { get; set; }
    }
}
