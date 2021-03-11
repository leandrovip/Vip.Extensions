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
    }
}