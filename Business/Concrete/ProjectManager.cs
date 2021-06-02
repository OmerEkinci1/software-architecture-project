using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        private IProjectDal _projectDal;

        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }

        public IResult Add(Project project)
        {
            _projectDal.Add(project);
            return new SuccessResult(Messages.ProjectAdded);
        }

        public IResult Delete(int projectID)
        {
            var project = _projectDal.Get(p => p.ProjectID == projectID);
            project.Status = false;
            _projectDal.Update(project);
            return new SuccessResult(Messages.ProjectDeleted);
        }
        public IResult Update(Project project)
        {
            var getProject = GetByID(project.ProjectID).Data;
            project.RemainingProjectTime = getProject.RemainingProjectTime;
            project.ActiveWorkerCount = getProject.ActiveWorkerCount;
            _projectDal.Update(project);
            return new SuccessResult(Messages.ProjectUpdated);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<ProjectDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<ProjectDetailDto>>(_projectDal.GetAll());
        }

        [CacheAspect(duration: 10)]
        public IDataResult<ProjectDetailDto> GetByID(int projectID)
        {
            return new SuccessDataResult<ProjectDetailDto>(_projectDal.GetByID(projectID));
        }

        [CacheAspect]
        public IDataResult<List<ProjectDetailDto>> GetProjectByUserID(int userID)
        {
            return new SuccessDataResult<List<ProjectDetailDto>>(_projectDal.GetProjectByUserID(userID));
        }

        
    }
}
