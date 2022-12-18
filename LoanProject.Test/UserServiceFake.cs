using LoanProject.Domain;
using LoanProject.Models;
using LoanProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProject.Test
{
    public class UserServiceFake : IUserServices
    {


        private readonly List<User> _userTest;

        public UserServiceFake()
        {
          _userTest = new List<User>()
            {
                new User() { Id = 1, FirstName = "test1", LastName = "test1", UserName = "test1", Password = "FGGRGSADGSDGS.",
                    Salt = "fwfWFFGDDDDSAADSF+++", Age = 4, Email = "gdgd@gmail.com", Role = "Admin", Salary = 111, IsBlocked = false
                },

                new User() { Id = 2, FirstName = "test2", LastName = "test2", UserName = "test2", Password = "sewsegwegsgseg.",
                    Salt = "segsegseghhhhhh+++", Age = 4, Email = "ttttgd@gmail.com", Role = "Admin", Salary = 111, IsBlocked = false
                },
                new User() { Id = 3, FirstName = "test3", LastName = "test3", UserName = "test3", Password = "sewsegwegsgseg.",
                    Salt = "segsegseghhhhhh+++", Age = 4, Email = "ttttgd@gmail.com", Role = "User", Salary = 111, IsBlocked = false
                },

            };
        }
        public bool CheckIfIsBlocked(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Loan>> DeleteLoan(Loan loan)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> DeleteUser(int id)
        {
            var existing = _userTest.First(a => a.Id == id);
            _userTest.Remove(existing);
            return  _userTest;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return _userTest;
        }

        public Task<List<Loan>> GetLoanByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Loan>> PostLoanByID(int UserId, LoanModel loanModel)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> PostUser(UserModel myUser)
        {
            throw new NotImplementedException();
        }

        public Task<Loan> PutLoan(int id, PutLoanModel loan, int LoanID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> PutUserBlock(int id, PutBlockedModel user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> UserByID(int id)
        {
            return _userTest.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
