using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class WorkerSalaryExperienceManager : IWorkerSalaryExperienceService
    {
        private IWorkerSalaryExperienceService _workerSalaryExperienceService;

        public WorkerSalaryExperienceManager(IWorkerSalaryExperienceService workerSalaryExperienceService)
        {
            _workerSalaryExperienceService = workerSalaryExperienceService;
        }
    }
}
