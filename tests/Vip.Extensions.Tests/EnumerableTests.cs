using System.Collections.Generic;
using Xunit;

namespace Vip.Extensions.Tests.Model
{
    public class EnumerableTests
    {
        [Fact]
        public void EnumerableTests_ExistsRepeated_DeveRetornarTrueCasoExistaRegistrosDuplicados()
        {
            // Arrange
            var listaProduto = new List<Produto> {Produto.Novo(), Produto.Novo()};

            // Act
            var retorno = listaProduto.ExistsRepeated(x => x.Descricao);

            // Assert
            Assert.True(retorno);
        }

        [Fact]
        public void EnumerableTests_ExistsRepeated_DeveRetornarFalseCasoNaoExistaRegistrosDuplicados()
        {
            // Arrange
            var produto = Produto.Novo();
            produto.Descricao = "PRODUTO DESCRICAO TESTE REPETIDO";
            var listaProduto = new List<Produto> {produto, Produto.Novo()};

            // Act
            var retornoTrue = listaProduto.NotExistsRepeated(x => x.Descricao);
            var retornoFalse = listaProduto.ExistsRepeated(x => x.Descricao);

            // Assert
            Assert.True(retornoTrue);
            Assert.False(retornoFalse);
        }
    }
}