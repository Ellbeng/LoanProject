using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProject.Domain
{
    public class Loan
    {
        public int ID { get; set; }
        public string LoanType { get;set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public int LoanPeriod { get; set; }
        public string Status { get;set; }
        public User User { get; set; }
        public int UserId { get; set; }
    } 


   public  enum LoanTypes 
    {
        Fast,
        Auto,
        Installment
    }
    public enum Statuses
    {
        Processing,
        Approved,
        Rejected
    }
}
