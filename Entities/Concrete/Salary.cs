using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Salary : IEntity
    {
        public Salary()
        {
            SalaryDate = DateTime.Now;
        }
        public int SalaryID { get; set; }
        public int WorkerID { get; set; }
        public int UserID { get; set; }
        public decimal SalaryAmount { get; set; }
        public DateTime SalaryDate { get; set; }
    }
}
