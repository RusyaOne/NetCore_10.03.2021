using Calculator;
using Xunit;

namespace CalculatorTests
{
    public class BasicOperationsTests
    {
        [Theory]
        [InlineData(3, 5, 8)]
        [InlineData(-5, 5, 0)]
        [InlineData(102312, 12498, 114810)]
        public void Add_TwoPositiveNumbers_ResultIsEqualToSumOfNumbers(int firstNumber, int secondNumber, int sum)
        {
            //Arrange
            BasicOperations sut = new BasicOperations();

            //Act
            int result = sut.Add(firstNumber, secondNumber);

            //Assert
            Assert.Equal(sum, result);
        }

        [Fact]
        public void Substract_TwoPositiveNumbers_ResultIsEqualToSubstraction()
        {
            BasicOperations sut = new BasicOperations();

            int result = sut.Add(-3, -5);

            Assert.Equal(8, result);
        }
    }
}