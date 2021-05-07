using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SalaryManager : ISalaryService
    {
        private ISalaryService _salaryService;

        public SalaryManager(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }
    }
}
