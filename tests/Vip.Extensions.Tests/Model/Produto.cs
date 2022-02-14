using System;

namespace Vip.Extensions.Tests.Model
{
    public class Produto
    {
        #region Propriedades

        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Numero { get; set; }
        public DateTime Validade { get; set; }
        public bool Inativo { get; set; }

        #endregion

        #region Constantes

        public const string DescricaoConst = "PRODUTO TESTE";
        public const decimal ValorConst = 15.254m;
        public const int NumeroConst = 12;

        #endregion

        #region Método Estatico

        public static Produto Novo() => new() {Descricao = DescricaoConst, Valor = ValorConst, Numero = NumeroConst, Validade = DateTime.Now};

        #endregion
    }
}