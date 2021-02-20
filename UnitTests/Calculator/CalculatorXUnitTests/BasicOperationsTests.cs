using Calculator;
using System;
using Xunit;

namespace CalculatorXUnitTests
{
    public class BasicOperationsTests
    {
        [Theory]
        [InlineData(5, 1, 6)]
        [InlineData(3, 3, 6)]
        [InlineData(-3, -3, -6)]
        public void Add_AddPositiveNumbers_ResultIsCorrect(int first, int second, int expected)
        {
            var basicOperations = new BasicOperations();

            var result = basicOperations.Add(first, second);

            Assert.Equal(result, expected);
        }
    }
}
