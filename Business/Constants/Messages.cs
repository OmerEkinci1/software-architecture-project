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
        public static string AuthorizationDenied = "";
        public static string UserRegistered = "";
        public static string UserNotFound = "";
        public static string PasswordError = "";
        public static string SuccessfulLogin = "";
        public static string UserAlreadyExists = "";
        public static string AccessTokenCreated = "";
        public static string CompensationAdded = "";
        public static string CompensationListed = "";
        public static string WorkerListed = "";
        public static string CompensationUpdated = "";
        public static string DepartmentAdded = "";
        public static string DepartmentUpdated = "";
        public static string WorkerAdded = "";
        public static string WorkerDeleted = "";
        public static string WorkerUpdated = "";
        public static string NotHaveAnyClaim="daldaldadlaldaldaldaldaldaldaldlald";
        internal static string UserListed;
        internal static string CompensationDeleted;
        internal static string OperationClaimAdded;
        internal static string OperationClaimDeleted;
        internal static string OperationClaimUpdated;
        internal static string ProjectSectionDepartmentAdded;
        internal static string ProjectSectionDepartmentDeleted;
        internal static string ProjectSectionDepartmentUpdate;
        internal static string ProjectSectionAdded;
        internal static string ProjectSectionDeleted;
        internal static string ProjectSectionUpdated;
        internal static string ProjectAdded;
        internal static string ProjectDeleted;
        internal static string ProjectUpdated;
        internal static string ProjectWorkerAdded;
        internal static string ProjectWorkerDeleted;
        internal static string ProjectWorkerUpdated;
        internal static string SalaryAdded;
        internal static string SalaryDeleted;
        internal static string SalaryUpdated;
        internal static string UserOperationClaimAdded;
        internal static string UserOperationClaimDeleted;
        internal static string UserOperationClaimUpdated;
        internal static string WorkerDepartmentTypeAdded;
        internal static string WorkerDepartmentTypeDeleted;
        internal static string WorkerDepartmentTypeUpdated;
        internal static string WorkerSalaryExperienceAdded;
        internal static string WorkerSalaryExperienceUpdated;
        internal static string UserDeleted;
        internal static string UserUpdated;
        internal static string UserAlreadyHaveCompensation;
        internal static string UserAlreadyHaveDepartment;
        internal static string OperationClaimAlreadyExist;
        internal static string DepartmentAlreadyExistInSection;
        internal static string NotDeleteWorker;

        public static string ProjectNotDeleted;
        public static string WorkerNotHaveSkill="Worker bu yetkinliğe sahip değil";
        public static string ProjectWorkerCapacityMaximum="Worker maxximum sayıda";
        public static string ProjectWorkerCapacityMinimum="Worker minimum sayıda";
        public static string AddedProjectWorkerWorkingTime="Worker çalışma saati eklendi işten çıkabilrisin";
        internal static string UpdatedProjectWorkerWorkingTime;
        internal static string CanNotUpdatedWorkingTime;
    }
}
