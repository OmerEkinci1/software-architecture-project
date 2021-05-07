using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WorkerManager>().As<IWorkerService>();
            builder.RegisterType<EfWorkerDal>().As<IWorkerDal>();

            builder.RegisterType<WorkerSalaryExperienceManager>().As<IWorkerSalaryExperienceService>();
            builder.RegisterType<EfWorkerSalaryExperienceDal>().As<IWorkerSalaryExperienceDal>();

            builder.RegisterType<SalaryManager>().As<ISalaryService>();
            builder.RegisterType<EfSalaryDal>().As<ISalaryDal>();

            builder.RegisterType<ProjectWorkerWorkingTimeManager>().As<IProjectWorkerWorkingTimeService>();
            builder.RegisterType<EfProjectWorkerWorkingTimeDal>().As<IProjectWorkerWorkingTimeDal>();

            builder.RegisterType<ProjectWorkerManager>().As<IProjectWorkerService>();
            builder.RegisterType<EfProjectWorkerDal>().As<IProjectWorkerDal>();

            builder.RegisterType<ProjectManager>().As<IProjectService>();
            builder.RegisterType<EfProjectDal>().As<IProjectDal>();

            builder.RegisterType<ProjectSectionManager>().As<IProjectSectionService>();
            builder.RegisterType<EfProjectSectionDal>().As<IProjectSectionDal>();

            builder.RegisterType<ProjectManagerManager>().As<IProjectManagerService>();
            builder.RegisterType<EfProjectManagerDal>().As<IProjectManagerDal>();

            builder.RegisterType<HRManager>().As<IHRService>();
            builder.RegisterType<EfHRDal>().As<IHRDal>();

            builder.RegisterType<DepartmentTypeManager>().As<IDepartmentTypeService>();
            builder.RegisterType<EfDepartmentTypeDal>().As<IDepartmentTypeDal>();

            builder.RegisterType<CompensationManager>().As<ICompensationService>();
            builder.RegisterType<EfCompensationDal>().As<ICompensationDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
