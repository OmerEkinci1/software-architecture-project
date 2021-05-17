using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ProjectWorkerWorkingTime : IEntity
    {
        public ProjectWorkerWorkingTime()
        {
            Date = DateTime.Now;
        }
        public int ProjectWorkerWorkingTimeID { get; set; }
        public int ProjectWorkerID { get; set; }
        public string DailyStartHour { get; set; }
        public string DailyFinishHour { get; set; }
        public DateTime Date { get; set; }
    }
}
