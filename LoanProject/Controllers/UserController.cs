using LoanPoject.Data;
using LoanProject.Domain;
using LoanProject.Models;
using LoanProject.Services;
using LoanProject.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace LoanProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        readonly ITokenServices _tokenServices;
        readonly IUserServices _userServices;
        readonly ILoginServices _loginServices;
        readonly IMapperServices _mapperServices;
        public readonly UserContext? _context;

        public UserController(IUserServices UserServices, UserContext context, ILoginServices loginServices, ITokenServices tokenServices, IMapperServices mapperServices)
        {
            _userServices = UserServices;
            _context = context;
            _loginServices = loginServices;
            _tokenServices = tokenServices;
            _mapperServices = mapperServices;
        }

        [HttpGet("person/{id}")]
        public async Task<ActionResult<List<UserModel>>> GetUserByID(int id)
        {

            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
                return Forbid();

            var user = await _userServices.UserByID(id);

            if (user == null)
                return NotFound();
            return Ok(user);
        }


        [Authorize(Roles = Role.Admin)]
        [HttpGet("GetAllUsers")]

        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers() => await _userServices.GetAllUsers();


        [AllowAnonymous]
        [HttpPost("Registration")]
        public async Task<ActionResult<IEnumerable<User>>> Registration(UserModel myUser)
        {
            UserValidator _validator = new UserValidator();
            var validResult = _validator.Validate(myUser);
            if (!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }
            var AllUserWithAdded = await _userServices.PostUser(myUser);
            return Ok(AllUserWithAdded);


        }


        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {

            var userLogin = _loginServices.Login(user);
            if (user == null)
                return BadRequest(new { message = "Username or Password is incorrect" });
            string tokenString = _tokenServices.GenerateToken(userLogin);
            return Ok(new
            {
                Id = userLogin.Id,
                Email = userLogin.Email,
                Token = tokenString
            });

        }




        [HttpPost("Loan/{id}")]
        public async Task<ActionResult<IEnumerable<Loan>>> AddLoanByID(int UserId, LoanModel loanModel)
        {

            var currentUserId = int.Parse(User.Identity.Name);
            if (UserId != currentUserId && !User.IsInRole(Role.Admin))
                return Forbid();


            if (_userServices.CheckIfIsBlocked(UserId) == true)
            {
                return NotFound("User is blocked");
            }
            var AllLoan = await _userServices.PostLoanByID(UserId, loanModel);

            return Ok(AllLoan);

        }


        [HttpGet("User/Loan/{id}")]
        public async Task<ActionResult<IEnumerable<LoanModel>>> GetLoanByID(int id)
        {

            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
                return Forbid();
            var loan = await _userServices.GetLoanByID(id);
            if (loan == null)
                return NotFound();
            return _mapperServices.AdaptLoanList(loan);

        }




        [Authorize(Roles = Role.Admin)]
        [HttpDelete("DELETE/{id}")]
        public async Task<ActionResult<IEnumerable<User>>> DeleteUser(int id)
        {
            var deleted = await _userServices.DeleteUser(id);
            return Ok(deleted);
        }



        [HttpDelete("DELETE/Loan/{id}")]
        public async Task<ActionResult<IEnumerable<Loan>>> DeleteLoan(int id, int LoanID)
        {

            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
                return Forbid();


            var loan = _context.Loan.Find(LoanID);
            if (loan.Status != Statuses.Processing.ToString() && !User.IsInRole(Role.Admin))
            {
                return NotFound("Status is not in Processing");
            }
            if (loan == null)
            {
                return Forbid("There id no Loan on this ID");
            }

            var deleteLoan = await _userServices.DeleteLoan(loan);
            return Ok(deleteLoan);

        }


        [Authorize(Roles = Role.Admin)]
        [HttpPut("Admin/Put/{id}")]
        public async Task<ActionResult<IEnumerable<User>>> PutUserBlock(int id, PutBlockedModel user)
        {
            var putBlock = await _userServices.PutUserBlock(id, user);
            return Ok(putBlock);

        }




        [HttpPut("Admin/Loan/Put/{id}")]
        public async Task<ActionResult<Loan>> PutLoan(int id, PutLoanModel loan, int LoanID)
        {
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
                return Forbid();

            if (loan.Status != Statuses.Processing.ToString() && !User.IsInRole(Role.Admin))
            {
                return NotFound("Status is not in Processing");
            }
            var changedloan = await _userServices.PutLoan(id, loan, LoanID);
            return Ok(changedloan);

        }






    }
}
