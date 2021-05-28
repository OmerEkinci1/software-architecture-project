using AutoMapper;
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
    public class ProjectWorkerManager : IProjectWorkerService
    {
        private IProjectWorkerDal _projectWorkerDal;
        private IProjectSectionDepartmentService _projectSectionDepartmentService;
        private IProjectSectionService _projectSectionService;
        private IProjectService _projectService;
        private IWorkerDepartmentTypeService _workerDepartmentTypeService;
        private IMapper _mapper;

        public ProjectWorkerManager(IProjectWorkerDal projectWorkerDal, IProjectSectionDepartmentService projectSectionDepartmentService, IProjectSectionService projectSectionService, IProjectService projectService, IWorkerDepartmentTypeService workerDepartmentTypeService,IMapper mapper)
        {
            _projectWorkerDal = projectWorkerDal;
            _projectSectionDepartmentService = projectSectionDepartmentService;
            _projectSectionService = projectSectionService;
            _projectService = projectService;
            _workerDepartmentTypeService = workerDepartmentTypeService;
            _mapper = mapper;
        }

        public IResult Add(ProjectWorker projectWorkers)
        {
            
            var getWorkerDepartments = _workerDepartmentTypeService.GetByWorkerID(projectWorkers.WorkerID).Data;
            var getDepartmentTypeInSection = _projectSectionDepartmentService.GetByID(projectWorkers.ProjectSectionDepartmentID).Data;
            var getProjectSection = _projectSectionService.GetBySectionID(getDepartmentTypeInSection.ProjectSectionID).Data;
            var getProject = _projectService.GetByID(getProjectSection.ProjectID).Data;

            IResult result = BusinessRules.Run(CheckProjectWorkerCapacityIsFull(getProject),CheckIfWorkerHasDepartment(getWorkerDepartments, getDepartmentTypeInSection));

            if (result!=null)
            {
                return result;
            }

            projectWorkers.Status = true;
            _projectWorkerDal.Add(projectWorkers);

            getProject.ActiveWorkerCount += 1;
            var getProjectMapper = _mapper.Map<Project>(getProject);
            _projectService.Update(getProjectMapper);

            getProjectSection.WorkerCount += 1;
            _projectSectionService.Update(getProjectSection);

            return new SuccessResult(Messages.ProjectWorkerAdded);
        }

        public IResult Delete(ProjectWorker projectWorkers)
        {
            var getDepartmentTypeInSection = _projectSectionDepartmentService.GetByID(projectWorkers.ProjectSectionDepartmentID).Data;
            var getProjectSection = _projectSectionService.GetBySectionID(getDepartmentTypeInSection.ProjectSectionID).Data;
            var getProject = _projectService.GetByID(getProjectSection.ProjectID).Data;

            IResult result = BusinessRules.Run(CheckIfProjectWorkerCapacityMin(getProject));

            if (result != null)
            {
                return result;
            }

            projectWorkers.Status = false;
            _projectWorkerDal.Update(projectWorkers);

            getProject.ActiveWorkerCount -= 1;
            var getProjectMapper = _mapper.Map<Project>(getProject);
            _projectService.Update(getProjectMapper);

            getProjectSection.WorkerCount -= 1;
            _projectSectionService.Update(getProjectSection);

            return new SuccessResult(Messages.ProjectWorkerDeleted);
        }

        public IResult Update(ProjectWorker projectWorkers)
        {
            var getWorkerDepartments = _workerDepartmentTypeService.GetByWorkerID(projectWorkers.WorkerID).Data;
            var getDepartmentTypeInSection = _projectSectionDepartmentService.GetByID(projectWorkers.ProjectSectionDepartmentID).Data;

            IResult result = BusinessRules.Run(CheckIfWorkerHasDepartment(getWorkerDepartments, getDepartmentTypeInSection));

            if (result != null)
            {
                return result;
            }

            _projectWorkerDal.Update(projectWorkers);
            return new SuccessResult(Messages.ProjectWorkerUpdated);
        }



        public IDataResult<List<ProjectWorkerGeneralDto>> GetAll()
        {
            var getProjectWorkers = _projectWorkerDal.GetAll();
            List<ProjectWorkerGeneralDto> projectWorkerGeneralDtos = GenerateProjectGeneral(getProjectWorkers);
            return new SuccessDataResult<List<ProjectWorkerGeneralDto>>(projectWorkerGeneralDtos);
        }

        public IDataResult<ProjectWorker> GetByID(int projectWorkerID)
        {
            return new SuccessDataResult<ProjectWorker>(_projectWorkerDal.Get(p=>p.ProjectWorkerID==projectWorkerID));
        }


        public IDataResult<ProjectWorkerGeneralDto> GetByProjectSectionDepartmentID(int projectSectionDepartmentID)
        {

            var getProjectWorker = _projectWorkerDal.GetByProjectSectionDepartmentID(projectSectionDepartmentID);
            ProjectWorkerGeneralDto projectWorkerGeneralDto = null;

            var getProjectSectionDepartment = _projectSectionDepartmentService.GetByID(getProjectWorker.ProjectSectionDepartmentID).Data;

            var getProjectSection = _projectSectionService.GetBySectionID(getProjectSectionDepartment.ProjectSectionID).Data;
            var getProject = _projectService.GetByID(getProjectSection.ProjectID).Data;

            projectWorkerGeneralDto = new ProjectWorkerGeneralDto()
            {
                projectDetail = getProject,
                projectSection = getProjectSection,
                projectSectionDepartments = getProjectSectionDepartment,
                projectWorkerDto = getProjectWorker
            };

            return new SuccessDataResult<ProjectWorkerGeneralDto>(projectWorkerGeneralDto);

        }



        public IDataResult<List<ProjectWorkerGeneralDto>> GetByWorkerID(int workerID)
        {
            var getProjectWorkers = _projectWorkerDal.GetByWorkerID(workerID);
            List<ProjectWorkerGeneralDto> projectWorkerGeneralDtos = GenerateProjectGeneral(getProjectWorkers);
            return new SuccessDataResult<List<ProjectWorkerGeneralDto>>(projectWorkerGeneralDtos);
        }



        private List<ProjectWorkerGeneralDto> GenerateProjectGeneral(List<ProjectWorkerDto> getProjectWorkers)
        {
            List<ProjectWorkerGeneralDto> projectWorkerGeneralDtos = new List<ProjectWorkerGeneralDto>();
            var sectionID = 0;
            ProjectSection getProjectSection = null;
            ProjectDetailDto getProject = null;
            foreach (var getProjectWorker in getProjectWorkers)
            {
                var getProjectSectionDepartment = _projectSectionDepartmentService.GetByID(getProjectWorker.ProjectSectionDepartmentID).Data;

                if (sectionID != getProjectSectionDepartment.ProjectSectionID)
                {
                    sectionID = getProjectSectionDepartment.ProjectSectionID;
                    getProjectSection = _projectSectionService.GetBySectionID(getProjectSectionDepartment.ProjectSectionID).Data;
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

            return projectWorkerGeneralDtos;
        }




        private IResult CheckProjectWorkerCapacityIsFull(ProjectDetailDto getProject)
        {
            if (getProject.MaxWorkerCount == getProject.ActiveWorkerCount)
            {
                return new ErrorResult(Messages.ProjectWorkerCapacityMaximum);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProjectWorkerCapacityMin(ProjectDetailDto getProject)
        {
            if (getProject.MinWorkerCount == getProject.ActiveWorkerCount)
            {
                return new ErrorResult(Messages.ProjectWorkerCapacityMinimum);
            }
            return new SuccessResult();
        }

        private IResult CheckIfWorkerHasDepartment(List<WorkerDepartmentType> getWorkerDepartments, ProjectSectionDepartmentDto getDepartmentTypeInSection)
        {
            bool checkDepartmentCompatibility = false;
            foreach (var workerDepartment in getWorkerDepartments)
            {
                if (workerDepartment.DepartmentTypeID == getDepartmentTypeInSection.DepartmentTypeID)
                {
                    checkDepartmentCompatibility = true;
                    break;
                }
            }

            if (!checkDepartmentCompatibility)
            {
                return new ErrorResult(Messages.WorkerNotHaveSkill);
            }
            return new SuccessResult();
        }

    }
}
