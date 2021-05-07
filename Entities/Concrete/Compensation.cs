using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Compensation : IEntity
    {
        public int CompensationID { get; set; }
        public int WorkerID { get; set; }
        public decimal CompensationAmount { get; set; }
        public DateTime CompensationDate { get; set; }
    }
}
