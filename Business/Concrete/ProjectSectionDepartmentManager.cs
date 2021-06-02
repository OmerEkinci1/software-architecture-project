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
    public class ProjectSectionDepartmentManager : IProjectSectionDepartmentService
    {
        private IProjectSectionDepartmentDal _projectSectionDepartmentDal;

        public ProjectSectionDepartmentManager(IProjectSectionDepartmentDal projectSectionDepartmentDal)
        {
            _projectSectionDepartmentDal = projectSectionDepartmentDal;
        }

        public IResult Add(ProjectSectionDepartment projectSectionDepartment)
        {
            IResult result = BusinessRules.Run(CheckIfDepartmentAlreadyExistInSection(projectSectionDepartment));
            if (result != null)
            {
                return result;
            }
            _projectSectionDepartmentDal.Add(projectSectionDepartment);
            return new SuccessResult(Messages.ProjectSectionDepartmentAdded);
        }

        public IResult Delete(ProjectSectionDepartment projectSectionDepartment)
        {
            projectSectionDepartment.Status = false;
            _projectSectionDepartmentDal.Update(projectSectionDepartment);
            return new SuccessResult(Messages.ProjectSectionDepartmentDeleted);
        }

        public IResult Update(ProjectSectionDepartment projectSectionDepartment)
        {
            IResult result = BusinessRules.Run(CheckIfDepartmentAlreadyExistInSection(projectSectionDepartment));
            if (result != null)
            {
                return result;
            }
            _projectSectionDepartmentDal.Update(projectSectionDepartment);
            return new SuccessResult(Messages.ProjectSectionDepartmentUpdate);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<ProjectSectionDepartmentDto>> GetAll()
        {
            return new SuccessDataResult<List<ProjectSectionDepartmentDto>>(_projectSectionDepartmentDal.GetAll());
        }

        //public IDataResult<List<ProjectSectionDepartmentDto>> GetByProjectID(int projectID)
        //{
        //    return new SuccessDataResult<List<ProjectSectionDepartmentDto>>(_projectSectionDepartmentDal.GetByProjectID(projectID));
        //}

        [CacheAspect(duration: 10)]
        public IDataResult<List<ProjectSectionDepartmentDto>> GetBySectionID(int sectionID)
        {
            return new SuccessDataResult<List<ProjectSectionDepartmentDto>>(_projectSectionDepartmentDal.GetBySectionID(sectionID));
        }

        [CacheAspect(duration: 10)]
        public IDataResult<ProjectSectionDepartmentDto> GetByID(int projectSectionDepartmentID)
        {
            return new SuccessDataResult<ProjectSectionDepartmentDto>(_projectSectionDepartmentDal.GetByID(projectSectionDepartmentID));
        }
        //public IDataResult<List<ProjectSectionDepartmentDto>> GetByUserID(int userID)
        //{
        //    return new SuccessDataResult<List<ProjectSectionDepartmentDto>>(_projectSectionDepartmentDal.GetByUserID(userID));

        //}

        private IResult CheckIfDepartmentAlreadyExistInSection(ProjectSectionDepartment projectSectionDepartment)
        {
            var result = _projectSectionDepartmentDal.GetAll(p => p.ProjectSectionID == projectSectionDepartment.ProjectSectionID).Find(p => p.DepartmentTypeID == projectSectionDepartment.DepartmentTypeID);

            if (result != null)
            {
                if (result.ProjectSectionDepartmentID!= projectSectionDepartment.ProjectSectionDepartmentID)
                {
                    return new ErrorResult(Messages.DepartmentAlreadyExistInSection);
                }
            }
            return new SuccessResult();
        }

        
    }
}
