using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BpstEducation.Models;

namespace BpstEducation.Data
{
    public static class ModelBuilderExtention
    { 
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole() { Id = "afa7a44a-e339-453a-8890-c48355bae2ae", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "afa7a44a-e339-453a-8890-c48355bae2ae" }, 
               new IdentityRole() { Id = "f7d29f7b-d49f-43b9-834e-7de644eccbcf", Name = "Staff", NormalizedName = "STAFF", ConcurrencyStamp = "f7d29f7b-d49f-43b9-834e-7de644eccbcf" }, 
               new IdentityRole() { Id = "7fd3a789-e48b-4ba5-941a-11cbc3b47f39", Name = "Student", NormalizedName = "STUDENT", ConcurrencyStamp = "a8388c90-9c2b-4260-8cb7-f4250d503afd" } 
               ); 
        }
        public static void SeedRegistrationStatusTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistrationStatusMaster>().HasData(
                new RegistrationStatusMaster() { UniqueId = 1, RegistrationStatus = "Applied" },
                new RegistrationStatusMaster() { UniqueId = 2, RegistrationStatus = "Reviewed" }
                );
        }
        public static void SeedCourseCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseCategory>().HasData(
            //    new CourseCategory() { UniqueId = 1, Name = "Basic Computer Course" },
                new CourseCategory() { UniqueId = 2, Name = "Programming Classes (for Rising Stars - IX - XII )" },
                new CourseCategory() { UniqueId = 3, Name = ".Net Internship " },
                new CourseCategory() { UniqueId = 4, Name = " Game Development" },
                new CourseCategory() { UniqueId = 5, Name = "Cyber Security" },
                new CourseCategory() { UniqueId = 6, Name = "Hardware/Networking" },
                new CourseCategory() { UniqueId = 7, Name = " Software Engineering Internship - 6 months " }, 
                new CourseCategory() { UniqueId = 8, Name = "Software Engineering Internship -  45 days " } ,
                new CourseCategory() { UniqueId = 9, Name = "others" } 
                );
        }
        public static void SeedQualificationCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Qualification>().HasData(
                new CourseCategory() { UniqueId = 1, Name = "Under Graduate " },
                new CourseCategory() { UniqueId = 2, Name = "Polytechnic / Diploma" },
                new CourseCategory() { UniqueId = 3, Name = "BCA" },
                new CourseCategory() { UniqueId = 4, Name = "B.Tech" },
                new CourseCategory() { UniqueId = 5, Name = "MCA" },
                new CourseCategory() { UniqueId = 6, Name = "Other" },
                new CourseCategory() { UniqueId = 7, Name = "N/A  " }
                );
        }

        public static void SeedEducationBoard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EducationBoardsMaster>().HasData(
                new EducationBoardsMaster() { UniqueId = 1, Name = "Central Board of Secondary Education (CBSE)", ShortName = "CBSE" },
                new EducationBoardsMaster() { UniqueId = 2, Name = "Council for the Indian School Certificate Examinations (CISCE)", ShortName = "CISCE" },
                new EducationBoardsMaster() { UniqueId = 3, Name = "National Institute of Open Schooling (NIOS)", ShortName = "NIOS" },
                new EducationBoardsMaster() { UniqueId = 4, Name = "Board of High School and Intermediate Education Uttar Pradesh (UP Board)", ShortName = "UP Board" },
                new EducationBoardsMaster() { UniqueId = 5, Name = "Jammu and Kashmir State Board of School Education (JKBOSE)", ShortName = "JKBOSE" },
                new EducationBoardsMaster() { UniqueId = 6, Name = " Board of Secondary Education Rajasthan (RBSE)", ShortName = "RBSE" },
                new EducationBoardsMaster() { UniqueId = 7, Name = "Himachal Pradesh Board of School Education (HPBOSE)", ShortName = "HPBOSE" },
                new EducationBoardsMaster() { UniqueId = 8, Name = "Madhya Pradesh Board of Secondary Education (MPBSE)", ShortName = "MPBSE" },
                new EducationBoardsMaster() { UniqueId = 9, Name = "Chhattisgarh Board of Secondary Education (CGBSE)", ShortName = "CGBSE" },
                new EducationBoardsMaster() { UniqueId = 10, Name = "Punjab School Education Board (PSEB)", ShortName = "PSEB" },
                new EducationBoardsMaster() { UniqueId = 11, Name = "Haryana Board of School Education (HBSE)", ShortName = "HBSE" },
                new EducationBoardsMaster() { UniqueId = 12, Name = "Bihar School Examination Board (BSEB)", ShortName = "BSEB" }
                );
        }
    }
}
