using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProjectWorkerManager : IProjectWorkerService
    {
        private IProjectWorkerDal _projectWorkerDal;

        public ProjectWorkerManager(IProjectWorkerDal projectWorkerDal)
        {
            _projectWorkerDal = projectWorkerDal;
        }
    }
}
