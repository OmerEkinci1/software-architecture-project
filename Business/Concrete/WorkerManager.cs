using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class WorkerManager : IWorkerService
    {
        private IWorkerService _workerService;

        public WorkerManager(IWorkerService workerService)
        {
            _workerService = workerService;
        }
    }
}
