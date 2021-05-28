using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Compensation : IEntity
    {
        public Compensation()
        {
            CompensationDate = DateTime.Now;
        }
        public int CompensationID { get; set; }
        public int WorkerID { get; set; }
        public int UserID { get; set; }
        public decimal CompensationAmount { get; set; }
        public DateTime CompensationDate { get; set; }
    }
}
