using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Worker : IEntity
    {
        public int WorkerID { get; set; }
        public Byte DepartmentTypeID { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public int DailyWorkingTime { get; set; }
        public decimal HourSalary { get; set; }
        public DateTime StartTime { get; set; }
        public bool Status { get; set; }
    }
}
