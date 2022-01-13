using Vip.Extensions.Tests.Model;
using Xunit;

namespace Vip.Extensions.Tests
{
    public class EnumTests
    {
        [Fact]
        public void EnumTests_AcaoDoTeste_ResultadoEsperado()
        {
            const int esperado1 = 1;
            const int esperado10 = 10;
            const int esperado400 = 400;

            // Act
            const TipoEnum valor1 = TipoEnum.Valor1;
            const TipoEnum valor10 = TipoEnum.Valor10;
            const TipoEnum valor400 = TipoEnum.Valor400;

            // Assert
            Assert.Equal(esperado1, valor1.ToInt());
            Assert.Equal(esperado10, valor10.ToInt());
            Assert.Equal(esperado400, valor400.ToInt());
        }
    }
}