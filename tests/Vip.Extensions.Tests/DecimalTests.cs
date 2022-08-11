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

        [Fact]
        public void DecimalTests_NotNegative_DeveRetornarZeroCasoInformadoNumeroNegativoComoDefault()
        {
            // Arrange
            const decimal valueInvalid = -10;
            const decimal defaultInvalid = -2;

            // Act
            var result = valueInvalid.NotNegative(defaultInvalid);

            // Assert
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(1.1)]
        [InlineData(2.99)]
        [InlineData(27.3)]
        [InlineData(28.9)]
        public void DecimalTests_Between_DeveRetornarTrueCasoNumeroForEntre1ponto1e28ponto9(decimal numero)
        {
            // Arrange
            const decimal numero1 = 1.1m;
            const decimal numero28 = 28.9m;

            // Act
            var retorno = numero.Between(numero1, numero28);

            // Assert
            Assert.True(retorno);
        }

        [Theory]
        [InlineData(-1.1)]
        [InlineData(0.2)]
        [InlineData(1)]
        [InlineData(29)]
        public void DecimalTests_Between_DeveRetornarFalseCasoNumeroNaoForEntre1ponto1e28ponto9(decimal numero)
        {
            // Arrange
            const decimal numero1 = 1.1m;
            const decimal numero28 = 28.9m;

            // Act
            var retorno = numero.NotBetween(numero1, numero28);

            // Assert
            Assert.True(retorno);
        }


        [Theory]
        [InlineData(1.99, 1)]
        [InlineData(0.2, 0)]
        [InlineData(1.3, 1)]
        public void DecimalTests_ToInt_DeveRetornarValorConvertido(decimal valorDecimal, int valorInt)
        {
            // Assert
            Assert.Equal(valorInt, valorDecimal.ToInt());
        }
    }
}