namespace LoanProject.Models
{
    public class PutLoanModel
    {
        public string LoanType { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public int LoanPeriod { get; set; }
        public string Status { get; set; }
    }
}
