using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    [TestClass]
    public class BasicOperationsTests
    {
        [TestMethod]
        public void Add_AddPositiveNumbers_ResultIsCorrect()
        {
            var basicOperations = new BasicOperations();

            //Мы вставляем произвольные значения, однако они должны быть указаны явно
            //Это означает, что не стоит применять никаких Math.Random() и тому подобных методов.
            //Тестовый метод должен быть максимально стабильным
            var result = basicOperations.Add(5, 1);

            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void Add_AddPositiveNumbersUsingAAA_ResultIsCorrect()
        {
            //Arrange
            var basicOperations = new BasicOperations();

            //Act
            var result = basicOperations.Add(5, 1);

            //Assert
            var expectedResult = 6;
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Add_AddNegativeNumbers_ResultIsCorrect()
        {
            //Lets try to use debug mode here
            //Arrange
            var basicOperations = new BasicOperations();

            //Act
            var result = basicOperations.Add(-5, -1);

            //Assert
            var expectedResult = -6;
            Assert.AreEqual(result, expectedResult);
        }

        //Напишите сами тест для метода Substract, 
        //при этом соблюдайте разделение теста на 3 логические части
    }
}
