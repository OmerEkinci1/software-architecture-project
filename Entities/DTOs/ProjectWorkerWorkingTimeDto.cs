using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectWorkerWorkingTimeDto : IDto
    {
        public int ProjectWorkerWorkingTimeID { get; set; }
        public int ProjectWorkerID { get; set; }
        public int WorkerID { get; set; }
        public string WorkerName { get; set; }
        public string WorkerSurname { get; set; }
        public string DailyStartHour { get; set; }
        public string DailyFinishHour { get; set; }
        public DateTime Date { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Subject { get; set; }
        // buradaki manager dedğişebilir belki göstermeyebiliriz.
        public int ManagerID { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
    }
}
