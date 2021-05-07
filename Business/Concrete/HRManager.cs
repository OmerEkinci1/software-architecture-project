using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class HRManager : IHRService
    {
        private IHRService _hRService;

        public HRManager(IHRService hRService)
        {
            _hRService = hRService;
        }
    }
}
