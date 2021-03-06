using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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

        public IResult Add(ProjectSection projectSection)
        {
            IResult result = BusinessRules.Run(CheckIfSectionNameAlreadyExistInProject(projectSection));
            if (result!=null)
            {
                return result;
            }
            projectSection.RemainingSectionTime = projectSection.SectionProjectTime;
            projectSection.WorkerCount = 0;
            projectSection.Status = true;
            _projectSectionDal.Add(projectSection);
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

        [CacheAspect(duration: 10)]
        public IDataResult<List<ProjectSection>> GetByProjectID(int projectID)
        {
            return new SuccessDataResult<List<ProjectSection>>(_projectSectionDal.GetAll(p=>p.ProjectID==projectID));
        }

        [CacheAspect(duration: 10)]
        public IDataResult<ProjectSection> GetBySectionID(int sectionID)
        {
            return new SuccessDataResult<ProjectSection>(_projectSectionDal.Get(p => p.ProjectSectionID == sectionID && p.Status == true));
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<ProjectSectionDto>> GetAll()
        {
            return new SuccessDataResult<List<ProjectSectionDto>>(_projectSectionDal.GetAll());
        }

        //public IDataResult<List<ProjectSectionDto>> GetByUserID(int userID)
        //{
        //    return new SuccessDataResult<List<ProjectSectionDto>>(_projectSectionDal.GetByUserID(userID));
        //}

        private IResult CheckIfSectionNameAlreadyExistInProject(ProjectSection projectSections)
        {
            var result = _projectSectionDal.GetAll(p => p.ProjectID == projectSections.ProjectID).Find(p => p.ProjectSectionName == projectSections.ProjectSectionName);

            if (result != null)
            {
                if (projectSections.ProjectSectionID!=result.ProjectSectionID)
                {
                    return new ErrorResult(Messages.DepartmentAlreadyExistInSection);
                }
            }
            return new SuccessResult();
        }

        
    }
}
