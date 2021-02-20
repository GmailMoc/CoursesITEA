using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorPrivateTests
{
    [TestClass]
    public class FluentOperationsTests
    {
        [TestMethod]
        public void Increment_ResultIsCorrect()
        {
            //Arrange
            var fluentOperations = new FluentOperations();
            PrivateObject privateFluentOperations = new PrivateObject(fluentOperations);

            //Act
            var result = privateFluentOperations.Invoke("Increment", 6);

            //Assert
            var expectedResult = 7;
            Assert.AreEqual(result, expectedResult);
        }
    }
}
