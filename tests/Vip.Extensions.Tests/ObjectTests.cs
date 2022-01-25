using System;
using Vip.Extensions.Tests.Model;
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

        [Fact]
        public void Object_GetValue_Decimal()
        {
            // Arrange
            var produto = Produto.Novo();

            // Act
            var property = produto.GetType().GetProperty("Valor");

            // Assert
            Assert.IsAssignableFrom<decimal>(property.GetValue<decimal>(produto));
            Assert.Equal(Produto.ValorConst, property.GetValue<decimal>(produto));
        }

        [Fact]
        public void Object_GetValue_DecimalInvalido()
        {
            // Arrange
            var produto = Produto.Novo();

            // Act
            var property = produto.GetType().GetProperty("ValorInvalido");

            // Assert
            Assert.IsAssignableFrom<decimal>(property.GetValue<decimal>(produto));
            Assert.Equal(0m, property.GetValue<decimal>(produto));
        }

        [Fact]
        public void Object_GetValue_String()
        {
            // Arrange
            var produto = Produto.Novo();

            // Act
            var property = produto.GetType().GetProperty("Descricao");

            // Assert
            Assert.IsAssignableFrom<string>(property.GetValue<string>(produto));
            Assert.Equal(Produto.DescricaoConst, property.GetValue<string>(produto));
        }

        [Fact]
        public void Object_GetValue_StringInvalido()
        {
            // Arrange
            var produto = Produto.Novo();

            // Act
            var property = produto.GetType().GetProperty("DescricaoInvalida");

            // Assert
            Assert.IsAssignableFrom<string>(property.GetValue<string>(produto));
            Assert.Equal(string.Empty, property.GetValue<string>(produto));
        }

        [Fact]
        public void Object_GetValue_Datetime()
        {
            // Arrange
            var produto = Produto.Novo();

            // Act
            var property = produto.GetType().GetProperty("Validade");

            // Assert
            Assert.IsAssignableFrom<DateTime>(property.GetValue<DateTime>(produto));
            Assert.True(DateTime.TryParse(property.GetValue<DateTime>(produto).ToString(), out _));
        }

        [Fact]
        public void Object_GetValue_DateTimeInvalido()
        {
            // Arrange
            var produto = Produto.Novo();

            // Act
            var property = produto.GetType().GetProperty("ValidadeInvalida");

            // Assert
            Assert.IsAssignableFrom<DateTime>(property.GetValue<DateTime>(produto));
            Assert.True(DateTime.TryParse(property.GetValue<DateTime>(produto).ToString(), out _));
        }

        [Fact]
        public void Object_Name_NameProperty()
        {
            // Arrange
            var produto = Produto.Novo();

            // Act
            var nome = produto.Name(x => x.Descricao);

            // Assert
            Assert.Equal("Descricao", nome);
        }

        [Fact]
        public void Object_FullName_FullNameProperty()
        {
            // Arrange
            var produto = Produto.Novo();

            // Act
            var nome = produto.FullName(x => x.Descricao);

            // Assert
            Assert.Equal("Produto.Descricao", nome);
        }
    }
}