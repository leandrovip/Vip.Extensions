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

        [Fact]
        public void IntTests_NotNegative_DeveRetornarZeroCasoInformadoNumeroNegativoComoDefault()
        {
            // Arrange
            const int valueInvalid = -10;
            const int defaultInvalid = -2;

            // Act
            var result = valueInvalid.NotNegative(defaultInvalid);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void IntTests_Division_DeveRetornarDivisaoCorreta()
        {
            // Arrange
            const int value = 10;
            const int denominator = 3;

            // Act
            var result = value.Division(denominator);

            // Assert
            Assert.Equal(3.33m, result);
        }
    }
}