using Core.Entites;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class WorkerDto:IDto
    {
        public int WorkerID { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public int DailyWorkingTime { get; set; }
        public decimal HourSalary { get; set; }
        public DateTime StartTime { get; set; }
        public bool Status { get; set; }
        public List<DepartmentType> DepartmentType{ get; set; }

    }
}
