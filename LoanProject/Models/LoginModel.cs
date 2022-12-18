namespace LoanProject.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public static class Role
    {

        public const string Admin = "Admin";
        public const string User = "User";

    }
}
