using Vip.Extensions.Tests.Helpers;
using Xunit;

namespace Vip.Extensions.Tests
{
    public class DecimalTests
    {
        [Theory]
        [InlineData(10, 50, 5)]
        [InlineData(25.22, 10, 2.522)]
        public void Decimal_ToPercentOf_DeveRetornarAPorcentagemReferenteAoValorFornecido(decimal value, decimal percent, decimal expected)
        {
            // Act
            var resultado = value.ToPercent(percent);

            // Assert
            Assert.Equal(expected, resultado);
        }

        [Theory]
        [ClassData(typeof(TestNotNegativeDecimals))]
        public void DecimalTests_NotNegative_ValorNaoDeveSerMenorQueZero(decimal valueInvalid)
        {
            // Arrange
            const decimal valueValid = 0m;

            // Act
            var result = valueInvalid.NotNegative();

            // Assert
            Assert.Equal(valueValid, result);
        }

        [Fact]
        public void DecimalTests_NotNegative_DeveRetornarMesmoValorCasoForMaiorQueZero()
        {
            // Arrange
            const decimal valueValid = 10;

            // Act
            var result = valueValid.NotNegative();

            // Assert
            Assert.Equal(valueValid, result);
        }

        [Fact]
        public void DecimalTests_NotNegative_DeveAssumirValorPadraoCasoForNegativo()
        {
            // Arrange
            const decimal valueInvalid = -10;
            const decimal valueDefault = 10;

            // Act
            var result = valueInvalid.NotNegative(valueDefault);

            // Assert
            Assert.Equal(valueDefault, result);
        }
    }
}