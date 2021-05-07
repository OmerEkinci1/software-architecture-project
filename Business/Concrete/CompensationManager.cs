using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CompensationManager : ICompensationService
    {
        private ICompensationService _compensationService;

        public CompensationManager(ICompensationService compensationService)
        {
            _compensationService = compensationService;
        }
    }
}
