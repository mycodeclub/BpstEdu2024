using BpstEducation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BpstEducation.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedRoles();
            modelBuilder.SeedRegistrationStatusTypes();
          //  modelBuilder.SeedEducationBoard(); Not required for now
            modelBuilder.SeedCourseCategory();
            modelBuilder.SeedQualificationCategory();
            modelBuilder.Entity<AppUser>().ToTable("AppUser");
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<StudentBatch> StudentBatch4 { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        
        public DbSet<EducationBoardsMaster> EducationBoards { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<RegistrationStatusMaster> RegistrationMasters { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<CodeHelper> CodeHelpers { get; set; }
        public DbSet<Fee> Fees { get; set; }

    }
}
