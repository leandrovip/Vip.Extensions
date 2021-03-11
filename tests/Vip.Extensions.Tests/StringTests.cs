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
    }
}