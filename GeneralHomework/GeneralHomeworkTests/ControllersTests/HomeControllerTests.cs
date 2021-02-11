using GeneralHomework.Controllers;
using GeneralHomework.Models;
using GeneralHomework.Models.Repositories;
using GeneralHomework.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GeneralHomeworkTests.ControllersTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void HomeController_Info_RepositoriesCalled()
        {
            //Arrange
            Mock<IHumanRepository> humanRepository = new Mock<IHumanRepository>();
            Mock<ICountryRepository> countryRepository = new Mock<ICountryRepository>();
            Mock<ILogger<HomeController>> logger = new Mock<ILogger<HomeController>>();
            Mock<IMessageSenderFactory> messageSenderFactory = new Mock<IMessageSenderFactory>();

            var humans = new List<Human> { new Human {
                Id = 1,
                FirstName = "",
                LastName = "",
                Age = 1,
                IsSick = false,
                Gender = Gender.Male,
                CountryId = 1,
                Country = null }};

            var countries = new List<Country> { new Country {
                Id = 1,
                Name = "",
                SickCount = 1,
                DeadCount = 1,
                Vaccine = false,
                Humans = null,
                RecoveredCount = 1,
                Population = 1 }};

            IMessageSender senders = null;

            //logger.Setup(x => x.LogDebug("message", "Warning"));
            humanRepository.Setup(x => x.GetAllHumans()).Returns(humans);
            countryRepository.Setup(x => x.GetAllCountries()).Returns(countries);
            messageSenderFactory.Setup(x => x.MailingType("email")).Returns(senders);

            HomeController homeController = new HomeController(humanRepository.Object, countryRepository.Object, messageSenderFactory.Object);

            //Act
            homeController.Info();

            //Assert
            humanRepository.Verify(x => x.GetAllHumans(), Times.Once);
            countryRepository.Verify(x => x.GetAllCountries(), Times.Once);
        }
    }
}
