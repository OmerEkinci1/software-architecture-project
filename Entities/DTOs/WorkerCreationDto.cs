using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class WorkerCreationDto:IDto
    {
        public WorkerCreationDto()
        {
            StartTime = DateTime.Now;
        }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public int DailyWorkingTime { get; set; }
        public decimal HourSalary { get; set; }
        public int UserID { get; set; }
        public DateTime StartTime { get; set; }
    }
}
