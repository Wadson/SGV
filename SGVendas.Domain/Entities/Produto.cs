namespace SGVendas.Domain.Entities
{
    /// <summary>
    /// Entidade de domínio Produto
    /// Representa a tabela dbo.Produtos do banco bdsiscontrol
    /// </summary>
    public class Produto
    {
        // Chave primária
        public int ProdutoID { get; set; }

        // Nome do produto
        public string NomeProduto { get; set; } = string.Empty;

        // Código de referência interno
        public string? Referencia { get; set; }

        // Preço de custo
        public decimal PrecoCusto { get; set; }

        // Margem de lucro
        public decimal Lucro { get; set; }

        // Preço final de venda
        public decimal PrecoDeVenda { get; set; }

        // Quantidade em estoque
        public int Estoque { get; set; }

        // Data de entrada do produto
        public DateTime DataDeEntrada { get; set; }

        // Status (Ativo / Inativo)
        public string Status { get; set; } = string.Empty;

        // Situação (ex: Normal, Promoção, etc.)
        public string? Situacao { get; set; }

        // Unidade (UN, KG, CX, etc.)
        public string? Unidade { get; set; }

        // Marca do produto
        public string? Marca { get; set; }

        // Data de validade (se aplicável)
        public DateTime? DataValidade { get; set; }

        // Código GTIN/EAN
        public string? GtinEan { get; set; }

        // Caminho da imagem
        public string? Imagem { get; set; }

        // Fornecedor (FK)
        public int? FornecedorID { get; set; }
    }
}
