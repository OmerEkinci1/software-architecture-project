using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Entites.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProjectGeneralManager : IProjectGeneralService
    {
        private IProjectService _projectService;
        private IProjectSectionService _projectSectionService;
        private IProjectSectionDepartmentService _projectSectionDepartmentService;
        private IMapper _mapper;

        public ProjectGeneralManager(IProjectService projectService, IProjectSectionService projectSectionService, IProjectSectionDepartmentService projectSectionDepartmentService,IMapper mapper)
        {
            _projectService = projectService;
            _projectSectionService = projectSectionService;
            _projectSectionDepartmentService = projectSectionDepartmentService;
            _mapper = mapper;
        }

        public IResult Add(ProjectCreationDto projectCreationDto)
        {
            var project = _mapper.Map<ProjectCreationDto, Project>(projectCreationDto);
            project.ActiveWorkerCount = 0;
            project.RemainingProjectTime = project.TotalDeclaredTime;
            project.Status = true;

            _projectService.Add(project);


            foreach (var projectSection in projectCreationDto.ProjectSections)
            {
                var psection = new ProjectSection
                {
                    ProjectID = project.ProjectID,
                    ProjectSectionName = projectSection.ProjectSectionName,
                    SectionProjectTime = projectSection.SectionProjectTime,
                };
                _projectSectionService.Add(psection);

                foreach (var projectSectionDepartment in projectSection.ProjectSectionDepartment)
                {
                    var psDepartment = new ProjectSectionDepartment
                    {
                        ProjectSectionID = psection.ProjectSectionID,
                        DepartmentTypeID = projectSectionDepartment.DepartmentTypeID,
                        Status = true
                    };

                    _projectSectionDepartmentService.Add(psDepartment);
                }
            }

            return new SuccessResult(Messages.ProjectAdded);

        }

        public IResult Delete(int projectID)
        {
            if (projectID != 0)
            {
                var result=_projectService.Delete(projectID);
                if (result.Success)
                {
                    return new SuccessResult(Messages.ProjectDeleted);
                }
            }
            return new ErrorResult(Messages.ProjectNotDeleted);
        }
        public IDataResult<ProjectGeneralDto> GetProjectByProjectID(int projectID)
        {
            var getProject = _projectService.GetByID(projectID).Data;
            var getAllProjectSection = _projectSectionService.GetByProjectID(getProject.ProjectID).Data;
            List<ProjectSectionKeepListDepartmentDto> projectSectionKeepList=new List<ProjectSectionKeepListDepartmentDto>();
            foreach (var projectSection  in getAllProjectSection)
            {
                var getListDepartments = _projectSectionDepartmentService.GetBySectionID(projectSection.ProjectSectionID).Data;
                ProjectSectionKeepListDepartmentDto projectSectionKeepListDepartmentDto = new ProjectSectionKeepListDepartmentDto()
                {
                    projectSection = projectSection,
                    projectSectionDepartmentDtos = getListDepartments
                };
                projectSectionKeepList.Add(projectSectionKeepListDepartmentDto);
            }

            ProjectGeneralDto projectGeneralDto = new ProjectGeneralDto()
            {
                ProjectDetailDto = getProject,
                projectSectionKeepListDepartments = projectSectionKeepList
            };

            return new SuccessDataResult<ProjectGeneralDto>(projectGeneralDto);


        }
        
    }
}
