using Xunit;

namespace Vip.Extensions.Tests
{
    public class StringTests
    {
        [Fact]
        public void String_TrimVip()
        {
            // Arrange
            const string valid = " TESTE ";

            // Act
            var value = valid.TrimVip();

            // Assert
            Assert.Equal("TESTE", value);
        }

        [Fact]
        public void String_IsNullOrEmpty()
        {
            // Act
            const string valid1 = "";
            string valid2 = null;
            const string invalid = "TESTE";

            // Assert
            Assert.True(valid1.IsNullOrEmpty());
            Assert.True(valid2.IsNullOrEmpty());
            Assert.False(invalid.IsNullOrEmpty());
        }

        [Fact]
        public void String_IsNotNullOrEmpty()
        {
            // Act
            const string valid = "TESTE";
            string invalid = null;

            // Assert
            Assert.True(valid.IsNotNullOrEmpty());
            Assert.False(invalid.IsNotNullOrEmpty());
        }

        [Fact]
        public void String_OnlyNumbers()
        {
            // Act
            const string valid = "ABC12345";
            const string invalid = "ABC";

            // Assert
            Assert.Equal("12345", valid.OnlyNumbers());
            Assert.Equal("", invalid.OnlyNumbers());
        }

        [Fact]
        public void String_RemoveAccent()
        {
            // Act
            const string expected = "aAaaoe";
            const string value = "àÁâãõé";

            // Assert
            Assert.Equal(expected, value.RemoveAccent());
        }

        [Fact]
        public void String_RemoveSpecialChars()
        {
            // Act
            const string expected = "teste";
            const string value = "[teste]";

            // Assert
            Assert.Equal(expected, value.RemoveSpecialChars());
        }

        [Fact]
        public void String_RemoveZeroLeft()
        {
            // Act
            const string expected = "123";
            const string value = "00000123";

            // Assert
            Assert.Equal(expected, value.RemoveZeroLeft());
        }

        [Fact]
        public void String_IsGtin_DeveRetornarFalseCasoGtinForFalso()
        {
            // Arrange
            const string codigoInvalido = "55";

            // Act
            var retorno = codigoInvalido.IsGtin();

            // Assert
            Assert.False(retorno);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("1234")]
        [InlineData("55")]
        [InlineData("123654")]
        [InlineData("1236978")]
        public void String_IsGtin_DeveRetornarFalseCasoGtinNaoConterTamanho8ou12ou13ou14(string codigoInvalido)
        {
            // Act
            var retorno = codigoInvalido.IsGtin();

            // Assert
            Assert.False(retorno);
        }

        [Theory]
        [InlineData("7896645900026")]
        [InlineData("7898908141016")]
        [InlineData("7893946087173")]
        [InlineData("7897186015095")]
        [InlineData("7891060886139")]
        [InlineData("7898132132019")]
        [InlineData("7506195185568")]
        [InlineData("12345670")]
        public void String_IsGtin_DeveRetornarTrueCasoGtinForValido(string codigoValido)
        {
            // Act
            var retorno = codigoValido.IsGtin();

            // Assert
            Assert.True(retorno);
        }

        [Fact]
        public void String_TryParse_DeveRetornarValorConvertido()
        {
            // Arrange
            const decimal expected = 121.32m;
            const string value = "121,32";

            // Act

            // Assert
            Assert.Equal(expected, value.TryParse<decimal>());
        }
    }
}