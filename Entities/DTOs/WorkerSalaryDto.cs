using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class WorkerSalaryDto : IDto
    {
        public int SalaryID { get; set; }
        public decimal SalaryAmount { get; set; }
        public DateTime SalaryDate { get; set; }
        public int WorkerID { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public bool WorkerStatus { get; set; }
        public int  DailyWorkingTime { get; set; }
        public decimal HourSalary { get; set; }
        public DateTime StartDate { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
