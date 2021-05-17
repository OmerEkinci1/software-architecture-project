﻿using Business.Abstract;
using Business.Constants;
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

        public IResult Delete(Project project)
        {
            //project = _projectDal.Get(p => p.ProjectID == project.ProjectID);
            project.Status = false;
            _projectDal.Update(project);
            return new SuccessResult(Messages.ProjectDeleted);
        }
        public IResult Update(Project project)
        {
            _projectDal.Update(project);
            return new SuccessResult(Messages.ProjectUpdated);
        }

        public IDataResult<List<ProjectDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<ProjectDetailDto>>(_projectDal.GetAll());
        }

        public IDataResult<ProjectDetailDto> GetByID(int projectID)
        {
            return new SuccessDataResult<ProjectDetailDto>(_projectDal.GetByID(projectID));
        }

        public IDataResult<List<ProjectDetailDto>> GetProjectByUserID(int userID)
        {
            return new SuccessDataResult<List<ProjectDetailDto>>(_projectDal.GetProjectByUserID(userID));
        }

        
    }
}
