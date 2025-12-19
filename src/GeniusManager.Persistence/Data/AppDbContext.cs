using System.Runtime.CompilerServices;
using GeniusManager.Domain.Entities.Lookups;
using GeniusManager.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GeniusManager.Persistence.Data
{

    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        #region DbSets for Entities presonality Porpertys
        public DbSet<Gender> Genders { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatuses {  get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }

        public DbSet<JobGrade> JobGrades { get; set; }
        public DbSet<JobGroup> JobGroups { get; set; }
        public DbSet<JobCareer> JobCareers { get; set; }


        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Gender
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<Gender>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<MaritalStatus>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<Religion>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<Nationality>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<Model>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<AppointmentType>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<EmployeeStatus>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<EducationLevel>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<Specialization>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<Qualification>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<JobGrade>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<JobGroup>());
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration<JobCareer>());




        }
    }
}