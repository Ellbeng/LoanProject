using AutoMapper;
using Humanizer.Localisation;
using LoanPoject.Data;
using LoanProject.Domain;
using LoanProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace LoanProject.Services
{


    public interface IUserServices
    {
        Task<List<User>> GetAllUsers();
        Task<List<UserModel>> UserByID(int id);
        Task<IEnumerable<User>> PostUser(UserModel myUser);
        Task<IEnumerable<Loan>> PostLoanByID(int UserId, LoanModel loanModel);
        Task<List<Loan>> GetLoanByID(int id);
        Task<IEnumerable<User>> DeleteUser(int id);
        Task<IEnumerable<Loan>> DeleteLoan(Loan loan);
        Task<IEnumerable<User>> PutUserBlock(int id, PutBlockedModel user);
        Task<Loan> PutLoan(int id, PutLoanModel loan, int LoanID);
        bool CheckIfIsBlocked(int id);
    }
    public class UserServices : IUserServices

    {
        readonly IMapperServices _mapperServices;
        public readonly UserContext? _context;
     
        private readonly int _iteration = 3;
        private readonly string _pepper;
        public UserServices(UserContext context, IMapperServices mapperServices)
        {
            _context = context;
            _mapperServices = mapperServices;
            _pepper = Environment.GetEnvironmentVariable("PasswordHashExamplePepper");
        }



        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }


        public async Task<List<UserModel>> UserByID(int id)
        {


            var user = await _context.Users.Where(x => x.Id == id).ToListAsync();

            return _mapperServices.AdaptUser(user);

        }


        public async Task<IEnumerable<User>> PostUser(UserModel myUser)
        {
            var user = new User()
            {
                UserName = myUser.UserName,
                FirstName = myUser.FirstName,
                LastName = myUser.LastName,
                Salt = PasswordHash.GenerateSalt(),
                Age = myUser.Age,
                Salary = myUser.Salary,
                IsBlocked = false,
                Email = myUser.Email,
                Role = Role.User,

            };
            user.Password = PasswordHash.ComputeHash(myUser.Password, user.Salt, _pepper, _iteration);
         

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }


        public async Task<IEnumerable<Loan>> PostLoanByID(int UserId, LoanModel loanModel)
        {






            var loan = new Loan()
            {
                LoanType = loanModel.LoanType,
                Amount = loanModel.Amount,
                Currency = loanModel.Currency,
                LoanPeriod = loanModel.LoanPeriod,
                Status = Statuses.Processing.ToString(),
                UserId = UserId,


            };


            _context.Loan.Update(loan);

            await _context.SaveChangesAsync();
            return await _context.Loan.ToListAsync();

        }


        public bool CheckIfIsBlocked(int id)
        {

            var user = _context.Users.Where(x => x.Id == id).First();
            if (user.IsBlocked == true)
            {
                return true;
            }
            else return false;

        }


        public async Task<List<Loan>> GetLoanByID(int id)
        {


            var loan = await _context.Loan.Where(x => x.UserId == id).ToListAsync();

            return loan;

        }


        public async Task<IEnumerable<User>> DeleteUser(int id)
        {



            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return await _context.Users.ToListAsync();

        }


        public async Task<IEnumerable<Loan>> DeleteLoan(Loan loan)
        {



            _context.Loan.Remove(loan);


            await _context.SaveChangesAsync();
            return await _context.Loan.ToListAsync();


        }


        public async Task<IEnumerable<User>> PutUserBlock(int id, PutBlockedModel user)
        {
            var changedUser = _context.Users.Find(id);


            changedUser.IsBlocked = user.IsBlocked;



            _context.Users.Update(changedUser);

            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();

        }


        public async Task<Loan> PutLoan(int id, PutLoanModel loan, int LoanID)
        {

            var changedloan = await _context.Loan.Where(x => x.UserId == id && x.ID == LoanID).FirstAsync();
            var putloan = _mapperServices.AdaptPutLoan(changedloan);


            changedloan.Status = loan.Status;
            changedloan.LoanPeriod = loan.LoanPeriod;
            changedloan.Currency = loan.Currency;
            changedloan.Amount = loan.Amount;
            changedloan.LoanType = loan.LoanType;
            _context.Loan.Update(changedloan);






            await _context.SaveChangesAsync();
            return changedloan;

        }
    }
}
