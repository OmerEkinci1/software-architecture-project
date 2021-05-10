using Business.Abstract;
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
    public class ProjectWorkerManager : IProjectWorkerService
    {
        private IProjectWorkerDal _projectWorkerDal;
        private IProjectSectionDepartmentService _projectSectionDepartmentService;
        private IProjectSectionService _projectSectionService;
        private IProjectService _projectService;

        public ProjectWorkerManager(IProjectWorkerDal projectWorkerDal, IProjectSectionDepartmentService projectSectionDepartmentService, IProjectSectionService projectSectionService, IProjectService projectService)
        {
            _projectWorkerDal = projectWorkerDal;
            _projectSectionDepartmentService = projectSectionDepartmentService;
            _projectSectionService = projectSectionService;
            _projectService = projectService;
        }

        public IResult Add(ProjectWorker projectWorkers)
        {
            _projectWorkerDal.Add(projectWorkers);
            return new SuccessResult(Messages.ProjectWorkerAdded);
        }

        public IResult Delete(ProjectWorker projectWorkers)
        {
            projectWorkers.Status = false;
            _projectWorkerDal.Update(projectWorkers);
            return new SuccessResult(Messages.ProjectWorkerDeleted);
        }

        public IResult Update(ProjectWorker projectWorkers)
        {
            _projectWorkerDal.Update(projectWorkers);
            return new SuccessResult(Messages.ProjectWorkerUpdated);
        }

        public IDataResult<List<ProjectWorkerGeneralDto>> GetAll()
        {
            var getProjectWorkers = _projectWorkerDal.GetAll();
            List<ProjectWorkerGeneralDto> projectWorkerGeneralDtos = new List<ProjectWorkerGeneralDto>();
            var sectionID = 0;
            ProjectSection getProjectSection=null;
            ProjectDetailDto getProject = null;
            foreach (var getProjectWorker in getProjectWorkers)
            {
                var getProjectSectionDepartment = _projectSectionDepartmentService.GetByID(getProjectWorker.ProjectSectionDepartmentID).Data;
                
                if (sectionID!=getProjectSectionDepartment.ProjectSectionID)
                {
                    sectionID = getProjectSectionDepartment.ProjectSectionID;
                     getProjectSection=_projectSectionService.GetBySectionID(getProjectSectionDepartment.ProjectSectionID).Data;
                     getProject = _projectService.GetByID(getProjectSection.ProjectID).Data;
                }

                ProjectWorkerGeneralDto projectWorkerGeneralDto = new ProjectWorkerGeneralDto()
                {
                    projectDetail = getProject,
                    projectSection = getProjectSection,
                    projectSectionDepartments = getProjectSectionDepartment,
                    projectWorkerDto = getProjectWorker
                };
                projectWorkerGeneralDtos.Add(projectWorkerGeneralDto);

            }
            return new SuccessDataResult<List<ProjectWorkerGeneralDto>>(projectWorkerGeneralDtos);
        }

        public IDataResult<ProjectWorkerDto> GetByProjectSectionDepartmentID(int projectSectionDepartmentID)
        {
            return new SuccessDataResult<ProjectWorkerDto>(_projectWorkerDal.GetByProjectSectionDepartmentID(projectSectionDepartmentID));
        }

        public IDataResult<List<ProjectWorkerGeneralDto>> GetByWorkerID(int workerID)
        {
            //return new SuccessDataResult<List<ProjectWorkerDto>>(_projectWorkerDal.GetByWorkerID(workerID));
            return null;
        }


    }
}
