using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class WorkerCompensationDto: IDto
    {
        public int WorkerID { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public int CompensationID { get; set; }
        public decimal CompensationAmount { get; set; }
        public DateTime CompensationDate { get; set; }
        public int DailyWorkingTime { get; set; }
        public decimal HourSalary { get; set; }
        public DateTime StartDate { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
