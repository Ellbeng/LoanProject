using LoanPoject.Data;
using LoanProject.Controllers;
using LoanProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace LoanProject.Test
{
    public class UserControllerTest
    {

    //////////  IS NOT WORKING    ///////////

        private readonly UserController _controller;
      
        readonly ITokenServices _tokenServices;
        readonly IUserServices _userServices;
        readonly ILoginServices _loginServices;
        readonly IMapperServices _mapperServices;
        public readonly UserContext? _context;


        public UserControllerTest(IUserServices UserServices, UserContext context, ILoginServices loginServices, ITokenServices tokenServices, IMapperServices mapperServices)
        {
            _userServices = new UserServiceFake();
            _context = context;
            _loginServices = loginServices;
            _tokenServices = tokenServices;
            _mapperServices = mapperServices;
            
            _controller = new UserController(_userServices, _context, _loginServices, _tokenServices, _mapperServices);
        }
        //[Fact]
        //public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        //{
        //    // Arrange
        //    var notExistingGuid = 8;

        //    // Act
        //    var badResponse = _controller.DeleteUser(notExistingGuid);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(badResponse);
        //}

        //[Fact]
        //public void Remove_ExistingGuidPassed_RemovesOneItem()
        //{
        //    // Arrange
        //    var existingGuid = 1;

        //    // Act
        //    var actual=_controller.DeleteUser(existingGuid);

        //    // Assert
        //    Assert.Equal(2, actual.count;
        //}







    }
}