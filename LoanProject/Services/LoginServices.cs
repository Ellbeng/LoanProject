using Humanizer.Localisation;
using LoanPoject.Data;
using LoanProject.Domain;
using LoanProject.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace LoanProject.Services
{
    public interface ILoginServices
    {
        User Login(LoginModel model);
    }

    public class LoginServices : ILoginServices
    {
        private readonly UserContext _context;
        private readonly int _iteration = 3;
        private readonly string _pepper;
        public LoginServices(UserContext context)
        {
            _context = context;
            _pepper = Environment.GetEnvironmentVariable("PasswordHashExamplePepper");
        }


        public User Login(LoginModel model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);

            if (user == null)
                return null;
            var passwordHash = PasswordHash.ComputeHash(model.Password, user.Salt, _pepper, _iteration);

            if (user.Password != passwordHash)
                return null;

        

            return user;
        }




    }
}
