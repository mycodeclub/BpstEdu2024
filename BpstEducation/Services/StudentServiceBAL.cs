using BpstEducation.Data;
using BpstEducation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Security.Claims;

namespace BpstEducation.Services
{
    public class StudentServiceBAL : IStudentServiceBAL
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserServiceBAL _loginManager;

        public StudentServiceBAL(AppDbContext dbContext,
             IUserServiceBAL loginManager)
        {
            _dbContext = dbContext;
            _loginManager = loginManager;
        }

    }
}
