using Xunit;

namespace Vip.Extensions.Tests
{
    public class ObjectTests
    {
        [Fact]
        public void Object_IsNull()
        {
            // Arrange
            object valueValid = null;
            object valueInvalid = "object";

            // Assert
            Assert.True(valueValid.IsNull());
            Assert.False(valueInvalid.IsNull());
        }

        [Fact]
        public void Object_IsNotNull()
        {
            // Act
            object valid = "value";
            object invalid = null;

            // Assert
            Assert.True(valid.IsNotNull());
            Assert.False(invalid.IsNotNull());
        }

        [Fact]
        public void Object_IsNullOrEmpty()
        {
            // Act
            object valid = "";
            object invalid = "TESTE";

            // Assert
            Assert.True(valid.IsNullOrEmpty());
            Assert.False(invalid.IsNullOrEmpty());
        }

        [Fact]
        public void Object_IsNotNullOrEmpty()
        {
            // Act
            object valid = "TESTE";
            object invalid = "";

            // Assert
            Assert.True(valid.IsNotNullOrEmpty());
            Assert.False(invalid.IsNotNullOrEmpty());
        }
    }
}