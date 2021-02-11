using GeneralHomework.Controllers;
using GeneralHomework.Models;
using GeneralHomework.ViewModels;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GeneralHomeworkTests.ControllersTests
{
    public class AccountControllerTests
    {
        [Fact]
        public void AccountController_Register_CreateCalledOnce()
        {
            //Arrange
            //чаще всего "мокаются" интерфейсы
            Mock<UserManager<CustomIdentityUser>> userManager = new Mock<UserManager<CustomIdentityUser>>(); // для успешного теста нужно добавить все зависимости в конструктор
            Mock<SignInManager<CustomIdentityUser>> signInManager = new Mock<SignInManager<CustomIdentityUser>>();

            AccountRegisterViewModel registerViewModel = new AccountRegisterViewModel
            {
                FisrtName = "TestFisrtName",
                LastName = "TestLastName",
                UserName = "TestUserName",
                Email = "TestEmail@mail.com",
                Password = "password",
                ConfirmPassword = "password"
            };

            CustomIdentityUser user = new CustomIdentityUser
            {
                FisrtName = registerViewModel.FisrtName,
                LastName = registerViewModel.LastName,
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email
            };

            userManager.Setup(x => x.CreateAsync(user, registerViewModel.Password)).ReturnsAsync(IdentityResult.Success);

            AccountController controller = new AccountController(userManager.Object, signInManager.Object);

            //Act
            controller.Register(registerViewModel);

            //Assert
            userManager.Verify(x => x.CreateAsync(user, registerViewModel.Password), Times.Once);
        }
    }
}
