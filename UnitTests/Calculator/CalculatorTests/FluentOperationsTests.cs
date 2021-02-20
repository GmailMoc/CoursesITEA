using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CalculatorTests
{
    [TestClass]
    public class FluentOperationsTests
    {
        [TestMethod]
        public void SomeComplexOperation_PassPositiveNumber_ResultIsCorrect()
        {
            //Arrange
            var fluentOperations = new FluentOperations();

            //Act
            var result = fluentOperations.SomeComplexOperation(6);

            //Assert
            var expectedResult = 5;
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Increment_ResultIsCorrect()
        {
            //Arange
            var fluentOperations = new FluentOperations();
            var fluentType = typeof(FluentOperations);
            var incrementMethod = fluentType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "Increment");

            //Act
            var result = (int)incrementMethod.Invoke(fluentOperations, new object[] { 6 });

            //Assert
            var expectedResult = 7;
            Assert.AreEqual(result, expectedResult);
        }

        //Напишите сами тест для метода Decrement
    }
}
