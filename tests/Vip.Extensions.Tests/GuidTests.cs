using System;
using Xunit;

namespace Vip.Extensions.Tests
{
    public class GuidTests
    {
        [Fact]
        public void GuidTests_IsEmpty_DeveRetornarTrueCasoGuidForVazio()
        {
            // Arrange
            var guidEmpty = Guid.Empty;

            // Assert
            Assert.True(guidEmpty.IsEmpty());
        }

        [Fact]
        public void GuidTests_IsNotEmpty_DeveRetornarTrueCasoGuidNaoForVazio()
        {
            // Arrange
            var guidEmpty = Guid.NewGuid();

            // Assert
            Assert.True(guidEmpty.IsNotEmpty());
        }
    }
}