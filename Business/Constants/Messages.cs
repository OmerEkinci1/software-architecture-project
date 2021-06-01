using Core.Entites.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string AuthorizationDenied = "You have no access";
        public static string UserRegistered = "User registered";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password Error";
        public static string SuccessfulLogin = "Successfull login";
        public static string UserAlreadyExists = "User already exist";
        public static string AccessTokenCreated = "Login Successfully";
        public static string CompensationAdded = "Compensation added";
        public static string CompensationListed = "Compensation Listed";
        public static string WorkerListed = "Worker Listed";
        public static string CompensationUpdated = "Compensation updated";
        public static string DepartmentAdded = "Department Added";
        public static string DepartmentUpdated = "Department updated";
        public static string WorkerAdded = "Worker added";
        public static string WorkerDeleted = "Worker deleted";
        public static string WorkerUpdated = "Worker updated";
        public static string NotHaveAnyClaim="Not have any claim";
        public static string UserListed = "User listed";
        public static string CompensationDeleted = "Compensation deleted";
        public static string OperationClaimAdded = "Claim added";
        public static string OperationClaimDeleted = "Claim deleted";
        public static string OperationClaimUpdated = "Claim updated";
        public static string ProjectSectionDepartmentAdded = "Project Section Department added";
        public static string ProjectSectionDepartmentDeleted = "Project Section Department deleted";
        public static string ProjectSectionDepartmentUpdate = "Project Section Department updated";
        public static string ProjectSectionAdded = "Project section added";
        public static string ProjectSectionDeleted = "Project section deleted";
        public static string ProjectSectionUpdated = "Project section updated";
        public static string ProjectAdded = "Project section added";
        public static string ProjectDeleted = "Project section deleted";
        public static string ProjectUpdated = "Project section updated";
        public static string ProjectWorkerAdded = "Project worker added";
        public static string ProjectWorkerDeleted = "Project worker deleted";
        public static string ProjectWorkerUpdated = "Project worker updated";
        public static string SalaryAdded = "Salary added";
        public static string SalaryDeleted = "Salary deleted";
        public static string SalaryUpdated = "Salary updated";
        public static string UserOperationClaimAdded = "User take the claim";
        public static string UserOperationClaimDeleted = "User remove the claim";
        public static string UserOperationClaimUpdated = "User update the claim";
        public static string WorkerDepartmentTypeAdded = "Department added to worker";
        public static string WorkerDepartmentTypeDeleted = "Department remove from worker";
        public static string WorkerDepartmentTypeUpdated = "Department updated for worker";
        public static string WorkerSalaryExperienceAdded =  "Worker salary experience added";
        public static string WorkerSalaryExperienceUpdated = "Worker salary experience updated";
        public static string UserDeleted = "User deleted";
        public static string UserUpdated = "User updated";
        public static string UserAlreadyHaveCompensation ="User already have compensation";
        public static string UserAlreadyHaveDepartment = "User already have department";
        public static string OperationClaimAlreadyExist = "Claim already exist";
        public static string DepartmentAlreadyExistInSection = "Department already exist in this section";
        public static string NotDeleteWorker = "Worker not delted";
        public static string ProjectNotDeleted = "Project not deleted";
        public static string WorkerNotHaveSkill="Worker cannot take this duty, because he is not have this skill.";
        public static string ProjectWorkerCapacityMaximum="Worker capacity maximum";
        public static string ProjectWorkerCapacityMinimum="Worker capacity minimum";
        public static string AddedProjectWorkerWorkingTime="Worker project working time, poject can leave from company.";
        public static string UpdatedProjectWorkerWorkingTime="Project worker working time updated.";
        public static string CanNotUpdatedWorkingTime = "Project worker working time cannot updated";
        public static string UserHasAlreadyOperationClaim="User Already Has That Operation Claim";
        public static string SalaryAlreadyExistThisMonth="Worker Has Already Take Money For This Month";
    }
}
