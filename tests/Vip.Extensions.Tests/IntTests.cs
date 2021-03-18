using Vip.Extensions.Tests.Helpers;
using Xunit;

namespace Vip.Extensions.Tests
{
    public class IntTests
    {
        [Theory]
        [ClassData(typeof(TestNotNegativeInteger))]
        public void IntTests_NotNegative_ValorNaoDeveSerMenorQueZero(int valueInvalid)
        {
            // Arrange
            const int valueValid = 0;

            // Act
            var result = valueInvalid.NotNegative();

            // Assert
            Assert.Equal(valueValid, result);
        }

        [Fact]
        public void IntTests_NotNegative_DeveRetornarMesmoValorCasoForMaiorQueZero()
        {
            // Arrange
            const int valueValid = 10;

            // Act
            var result = valueValid.NotNegative();

            // Assert
            Assert.Equal(valueValid, result);
        }

        [Fact]
        public void IntTests_NotNegative_DeveAssumirValorPadraoCasoForNegativo()
        {
            // Arrange
            const int valueInvalid = -10;
            const int valueDefault = 10;

            // Act
            var result = valueInvalid.NotNegative(valueDefault);

            // Assert
            Assert.Equal(valueDefault, result);
        }
    }
}