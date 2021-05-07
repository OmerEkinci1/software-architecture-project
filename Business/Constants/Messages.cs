using Core.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static SerializationInfo AuthorizationDenied { get; internal set; }
        public static string UserRegistered { get; internal set; }
        public static User UserNotFound { get; internal set; }
        public static User PasswordError { get; internal set; }
        public static string SuccessfulLogin { get; internal set; }
        public static object UserAlreadyExists { get; internal set; }
        public static string AccessTokenCreated { get; internal set; }
        public static string CompensationAdded { get; internal set; }
        public static string CompensationListed { get; internal set; }
        public static string WorkerListed { get; internal set; }
        public static string CompensationUpdated { get; internal set; }
        public static string DepartmentAdded { get; internal set; }
        public static string DepartmentDeleted { get; internal set; }
        public static string DepartmentUpdated { get; internal set; }
        public static string HRAdded { get; internal set; }
        public static string HRDeleted { get; internal set; }
        public static string HRUpdated { get; internal set; }
        public static string WorkerAdded { get; internal set; }
        public static string WorkerDeleted { get; internal set; }
        public static string WorkerUpdated { get; internal set; }
        public static string ProjectManagerAdded { get; internal set; }
        public static string ProjectManagerDeleted { get; internal set; }
        public static string ProjectManagerUpdated { get; internal set; }
    }
}
