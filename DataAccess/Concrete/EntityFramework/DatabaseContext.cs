using Core.Entites.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-T7O5H9H;Database=YazılımMimarisi;User = Omer; Password = 123;Trusted_Connection=true;");
        }

        public DbSet<Compensation> Compensations { get; set; }
        public DbSet<DepartmentType> DepartmentTypes { get; set; }
        public DbSet<HR> HRs { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectSection> ProjectSections { get; set; }
        public DbSet<ProjectWorker> ProjectWorkers { get; set; }
        public DbSet<ProjectWorkerWorkingTime> ProjectWorkerWorkingTimes { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkerSalaryExperience> WorkerSalaryExperiences { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
