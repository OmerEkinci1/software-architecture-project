using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SalaryManager : ISalaryService
    {
        private ISalaryDal _salaryDal;

        public SalaryManager(ISalaryService salaryService)
        {
            _salaryDal = salaryDal;
        }
    }
}
