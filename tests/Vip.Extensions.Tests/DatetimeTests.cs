using System;
using Xunit;

namespace Vip.Extensions.Tests
{
    public class DatetimeTests
    {
        [Fact]
        public void DateTime_BetweenIn_DeveRetornarTrueCasoDataInformadaEstiverEntreAsDatasDeParametro()
        {
            // Arrange
            var startDate = DateTime.Now.AddDays(-15);
            var endDate = DateTime.Now.AddMonths(1);

            // Act
            var result = DateTime.Now.BetweenIn(startDate, endDate);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DataTime_BetweenIn_DeveRetornarFalseCasoDataInformadaNaoForEntreAsDatasParametro()
        {
            // Arrange
            var startDate = DateTime.Now.AddYears(-2);
            var endDate = DateTime.Now.AddYears(-1);

            // Act
            var result = DateTime.Now.BetweenIn(startDate, endDate);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DateTimes_IsLowerOrEqualToday_DeveRetornarTrueCasoDataInformadaForMenorOuIgualDataAtual()
        {
            // Arrange
            var dateLower = DateTime.Now.AddDays(-1);

            // Act
            var retorno = dateLower.IsLowerOrEqualToday();

            // Assert
            Assert.True(retorno);
        }

        [Fact]
        public void DateTime_IsLowerOrEqualToday_DeveRetornarFalseCasoDataForMaiorQueDataAtual()
        {
            // Arrange
            var dateGreater = DateTime.Now.AddDays(1);

            // Act
            var retorno = dateGreater.IsLowerOrEqualToday();

            // Assert
            Assert.False(retorno);
        }

        [Fact]
        public void DateTime_DaysInMonth_DeveRetornarQuantidadeDeDiasDeUmMes()
        {
            // Arrange
            const int valorEsperado = 30;
            var data = new DateTime(2020, 11, 20);

            // Act
            var resultado = data.DaysInMonth();

            // Assert
            Assert.Equal(valorEsperado, resultado);
        }

        [Fact]
        public void DateTime_FirstDayOfMonth_DeveRetornarDataComPrimeiroDiaDoMes()
        {
            // Arrange
            var dataEsperada = new DateTime(2020, 11, 1);
            var data = new DateTime(2020, 11, 20);

            // Act
            var resultado = data.FirstDayOfMonth();

            // Assert
            Assert.Equal(dataEsperada, resultado);
        }

        [Fact]
        public void DateTime_LastDayOfMonth_DeveRetornarDataComUltimoDiaDoMes()
        {
            // Arrange
            var dataEsperada = new DateTime(2020, 11, 30);
            var data = new DateTime(2020, 11, 20);

            // Act
            var resultado = data.LastDayOfMonth();

            // Assert
            Assert.Equal(dataEsperada, resultado);
        }
    }
}