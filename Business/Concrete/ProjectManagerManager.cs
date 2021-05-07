using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProjectManagerManager : IProjectManagerService
    {
        private IProjectManagerDal _projectManagerDal;

        public ProjectManagerManager(IProjectManagerDal projectManagerDal)
        {
            _projectManagerDal = projectManagerDal;
        }

        public IResult Add(ProjectManager projectManager)
        {
            _projectManagerDal.Add(projectManager);
            return new SuccessResult(Messages.ProjectManagerAdded);
        }

        public IResult Delete(ProjectManager projectManager)
        {
            _projectManagerDal.Delete(projectManager);
            return new SuccessResult(Messages.ProjectManagerDeleted);
        }

        public IDataResult<ProjectManager> Get(int managerID)
        {
            return new SuccessDataResult<ProjectManager>(_projectManagerDal.Get(p => p.ManagerID == managerID));
        }

        public IResult Update(ProjectManager projectManager)
        {
            _projectManagerDal.Update(projectManager);
            return new SuccessResult(Messages.ProjectManagerUpdated);
        }
    }
}
