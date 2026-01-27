using System;
using System.Collections.Generic;
using System.Text;

namespace SGVendas.Domain.Entities
{
    public class MovimentacaoEstoque
    {
        public int MovimentacaoID { get; set; }

        public int ProdutoID { get; set; }

        public string TipoMovimentacao { get; set; } = null!;

        public int Quantidade { get; set; }

        public int EstoqueAnterior { get; set; }

        public int EstoqueAtual { get; set; }

        public string Origem { get; set; } = null!;

        public string? Documento { get; set; }

        public string? Observacao { get; set; }

        public DateTime DataMovimentacao { get; set; }

        public string? Usuario { get; set; }

        public virtual Produto Produto { get; set; } = null!;
    }
}
