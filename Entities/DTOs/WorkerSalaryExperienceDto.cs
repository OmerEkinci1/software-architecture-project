using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class WorkerSalaryExperienceDto : IDto
    {
        public int WorkerSalaryExperienceID { get; set; }
        public Byte DepartmentTypeID { get; set; }
        public string DepartmentTypeName { get; set; }
        public Byte Year { get; set; }
        public decimal minHourSalary { get; set; }
        public decimal maxHourSalary { get; set; }
    }
}
