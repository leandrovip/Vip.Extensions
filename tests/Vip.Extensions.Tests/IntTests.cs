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

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(27)]
        [InlineData(28)]
        public void IntTests_Between_DeveRetornarTrueCasoNumeroForEntre1e28(int numero)
        {
            // Arrange
            const int numero1 = 1;
            const int numero28 = 28;

            // Act
            var retorno = numero.Between(numero1, numero28);

            // Assert
            Assert.True(retorno);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(29)]
        public void IntTests_Between_DeveRetornarFalseCasoNumeroNaoForEntre1e28(int numero)
        {
            // Arrange
            const int numero1 = 1;
            const int numero28 = 28;

            // Act
            var retorno = numero.NotBetween(numero1, numero28);

            // Assert
            Assert.True(retorno);
        }
    }
}