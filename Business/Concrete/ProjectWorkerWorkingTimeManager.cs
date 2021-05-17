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
    public class ProjectWorkerWorkingTimeManager : IProjectWorkerWorkingTimeService
    {
        private IProjectWorkerWorkingTimeDal _projectWorkerWorkingTimeDal;
        private IProjectWorkerService _projectWorkerService;
        private IProjectSectionDepartmentService _projectSectionDepartmentService;
        private IProjectSectionService _projectSectionService;
        private IProjectService _projectService;
        private IWorkerService _workerService;
        private IMapper _mapper;
        private ISalaryService _salaryService;

        public ProjectWorkerWorkingTimeManager(IProjectWorkerWorkingTimeDal projectWorkerWorkingTimeDal, IProjectWorkerService projectWorkerService, IProjectSectionDepartmentService projectSectionDepartmentService, IProjectSectionService projectSectionService, IProjectService projectService, IWorkerService workerService,IMapper mapper,ISalaryService salaryService)
        {
            _projectWorkerWorkingTimeDal = projectWorkerWorkingTimeDal;
            _projectWorkerService = projectWorkerService;
            _projectSectionDepartmentService = projectSectionDepartmentService;
            _projectSectionService = projectSectionService;
            _projectService = projectService;
            _workerService = workerService;
            _mapper = mapper;
            _salaryService = salaryService;
        }

        public IResult Add(ProjectWorkerWorkingTime projectWorkerWorkingTime)
        {
            _projectWorkerWorkingTimeDal.Add(projectWorkerWorkingTime);

            var getProjectWorker = _projectWorkerService.GetByID(projectWorkerWorkingTime.ProjectWorkerID).Data;
            var getProjectSectionDepartment = _projectSectionDepartmentService.GetByID(getProjectWorker.ProjectSectionDepartmentID).Data;
            var getProjectSection = _projectSectionService.GetBySectionID(getProjectSectionDepartment.ProjectSectionID).Data;
            var getProject = _projectService.GetByID(getProjectSection.ProjectID).Data;
            var getWorker = _workerService.GetByID(getProjectWorker.WorkerID).Data;
            var getWorkerSalary = _salaryService.GetByWorkerID(getWorker.WorkerID).Data;

            decimal getWorkTime = Convert.ToDecimal(projectWorkerWorkingTime.DailyFinishHour) - Convert.ToDecimal(projectWorkerWorkingTime.DailyStartHour);
            getWorkTime.ToString().Insert(1, ".");


            getProject.RemainingProjectTime -= getWorkTime;
            getProjectSection.RemainingSectionTime -= getWorkTime;

            var getProjectMapper = _mapper.Map<Project>(getProject);
            _projectService.Update(getProjectMapper);
            _projectSectionService.Update(getProjectSection);

            var WorkerEarnPrice = getWorkTime * getWorker.HourSalary;

            var getSalaryMapper = _mapper.Map<Salary>(getWorkerSalary);

            getSalaryMapper.SalaryAmount += WorkerEarnPrice;

            if ((DateTime.Now - Convert.ToDateTime(getSalaryMapper.SalaryDate)).Days>30)
            {
                Salary salary = new Salary
                {
                    UserID = getSalaryMapper.UserID,
                    WorkerID = getSalaryMapper.WorkerID,
                    SalaryAmount = WorkerEarnPrice
                };
                _salaryService.Add(salary);
            }
            else
            {
                _salaryService.Update(getSalaryMapper);
            }

            return new SuccessResult(Messages.AddedProjectWorkerWorkingTime);
        }



        public IResult Update(ProjectWorkerWorkingTime projectWorkerWorkingTime)
        {
            var getOldVersion = GetByProjectWorkerWorkingTimeID(projectWorkerWorkingTime.ProjectWorkerWorkingTimeID).Data;
            IResult result = BusinessRules.Run(ChechkUpdatedIsToday(projectWorkerWorkingTime, getOldVersion));

            if (result!=null)
            {
                return result;
            }

            
            _projectWorkerWorkingTimeDal.Update(projectWorkerWorkingTime);

            var getProjectWorker = _projectWorkerService.GetByID(projectWorkerWorkingTime.ProjectWorkerID).Data;
            var getProjectSectionDepartment = _projectSectionDepartmentService.GetByID(getProjectWorker.ProjectSectionDepartmentID).Data;
            var getProjectSection = _projectSectionService.GetBySectionID(getProjectSectionDepartment.ProjectSectionID).Data;
            var getProject = _projectService.GetByID(getProjectSection.ProjectID).Data;
            var getWorker = _workerService.GetByID(getProjectWorker.WorkerID).Data;
            var getWorkerSalary = _salaryService.GetByWorkerID(getWorker.WorkerID).Data;

            decimal getWorkTime = Convert.ToDecimal(projectWorkerWorkingTime.DailyFinishHour) - Convert.ToDecimal(projectWorkerWorkingTime.DailyStartHour);
            getWorkTime.ToString().Insert(1, ".");

            decimal getOldWorkTime = Convert.ToDecimal(getOldVersion.DailyFinishHour) - Convert.ToDecimal(getOldVersion.DailyStartHour);
            getWorkTime.ToString().Insert(1, ".");


            getProject.RemainingProjectTime += getOldWorkTime;
            getProjectSection.RemainingSectionTime += getOldWorkTime;

            getProject.RemainingProjectTime -= getWorkTime;
            getProjectSection.RemainingSectionTime -= getWorkTime;

            var getProjectMapper = _mapper.Map<Project>(getProject);
            _projectService.Update(getProjectMapper);
            _projectSectionService.Update(getProjectSection);

            var WorkerEarnPrice = getWorkTime * getWorker.HourSalary;
            var WorkerOldEarnPrice = getOldWorkTime * getWorker.HourSalary;

            var getSalaryMapper = _mapper.Map<Salary>(getWorkerSalary);

            getSalaryMapper.SalaryAmount -= WorkerOldEarnPrice;
            getSalaryMapper.SalaryAmount += WorkerEarnPrice;


            _salaryService.Update(getSalaryMapper);

            return new SuccessResult(Messages.UpdatedProjectWorkerWorkingTime);
        }

        public IDataResult<List<ProjectWorkerWorkingTimeDto>> GetAll()
        {
            return new SuccessDataResult<List<ProjectWorkerWorkingTimeDto>>(_projectWorkerWorkingTimeDal.GetAll());
        }

        public IDataResult<List<ProjectWorkerWorkingTimeDto>> GetByProjectWorkerID(int projectWorkerID)
        {
            return new SuccessDataResult<List<ProjectWorkerWorkingTimeDto>>(_projectWorkerWorkingTimeDal.GetByProjectWorkerID(projectWorkerID));
        }


        public IDataResult<ProjectWorkerWorkingTime> GetByProjectWorkerWorkingTimeID(int projectWorkerWorkingTimeID)
        {
            return new SuccessDataResult<ProjectWorkerWorkingTime>(_projectWorkerWorkingTimeDal.Get(p => p.ProjectWorkerWorkingTimeID == projectWorkerWorkingTimeID));
        }

        private IResult ChechkUpdatedIsToday(ProjectWorkerWorkingTime newprojectWorkerWorkingTime, ProjectWorkerWorkingTime oldprojectWorkerWorkingTime)
        {
            if (oldprojectWorkerWorkingTime.Date.Date != newprojectWorkerWorkingTime.Date.Date)
            {
                return new ErrorResult(Messages.CanNotUpdatedWorkingTime);
            }
            return new SuccessResult();
        }

    }
}
