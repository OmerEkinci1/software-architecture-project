using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(ProjectSection projectSections)
        {
            IResult result = BusinessRules.Run(CheckIfSectionNameAlreadyExistInProject(projectSections));
            if (result!=null)
            {
                return result;
            }
            _projectSectionDal.Add(projectSections);
            return new SuccessResult(Messages.ProjectSectionAdded);
        }

        public IResult Delete(ProjectSection projectSections)
        {
            projectSections.Status = false;
            _projectSectionDal.Update(projectSections);
            return new SuccessResult(Messages.ProjectSectionDeleted);
        }
        public IResult Update(ProjectSection projectSections)
        {
            IResult result = BusinessRules.Run(CheckIfSectionNameAlreadyExistInProject(projectSections));
            if (result != null)
            {
                return result;
            }
            _projectSectionDal.Update(projectSections);
            return new SuccessResult(Messages.ProjectSectionUpdated);
        }

        public IDataResult<List<ProjectSection>> GetByProjectID(int projectID)
        {
            return new SuccessDataResult<List<ProjectSection>>(_projectSectionDal.GetAll(p=>p.ProjectID==projectID && p.Status==true));
        }
        public IDataResult<ProjectSection> GetBySectionID(int sectionID)
        {
            return new SuccessDataResult<ProjectSection>(_projectSectionDal.Get(p => p.ProjectSectionID == sectionID && p.Status == true));
        }

        //public IDataResult<List<ProjectSectionDto>> GetByUserID(int userID)
        //{
        //    return new SuccessDataResult<List<ProjectSectionDto>>(_projectSectionDal.GetByUserID(userID));
        //}

        private IResult CheckIfSectionNameAlreadyExistInProject(ProjectSection projectSections)
        {
            var result = _projectSectionDal.GetAll(p => p.ProjectSectionID == projectSections.ProjectSectionID).Find(p => p.ProjectSectionName == projectSections.ProjectSectionName);

            if (result != null)
            {
                return new ErrorResult(Messages.DepartmentAlreadyExistInSection);
            }
            return new SuccessResult();
        }

       
    }
}
