namespace LoanProject.Models
{
    public class LoanModel
    {
        public string LoanType { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public int LoanPeriod { get; set; }
        public int UserId { get; set; }
        public int ID { get; set; }
        //  public string Status { get; set; }
    }
}
