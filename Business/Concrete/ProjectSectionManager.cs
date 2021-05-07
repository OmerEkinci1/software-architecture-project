using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProjectSectionManager : IProjectSectionService
    {
        private IProjectSectionDal _projectSectionDal;

        public ProjectSectionManager(IProjectSectionDal projectSectionDal)
        {
            _projectSectionDal = projectSectionDal;
        }
    }
}
