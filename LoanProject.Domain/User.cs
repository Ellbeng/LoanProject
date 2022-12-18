using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProject.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public bool IsBlocked { get; set; }
        public List<Loan> Loans { get; set; } = new List<Loan>();
        public string? Role { get;set; }
        public string Salt { get;set;}
    }
}
