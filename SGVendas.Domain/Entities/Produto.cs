using SGVendas.Domain.Entities;

public partial class Produto
{
    public int ProdutoID { get; set; }

    public string NomeProduto { get; set; } = null!;

    public string? Referencia { get; set; }

    public decimal PrecoCusto { get; set; }

    public decimal Lucro { get; set; }

    public decimal PrecoDeVenda { get; set; }

    public int Estoque { get; set; }

    public DateTime DataDeEntrada { get; set; }

    public string Status { get; set; } = null!;

    public string? Situacao { get; set; }

    public string? Unidade { get; set; }

    public string? Marca { get; set; }

    public DateTime? DataValidade { get; set; }

    public string? GtinEan { get; set; }

    public string? Imagem { get; set; }

    public int? FornecedorID { get; set; }

    public virtual Fornecedor? Fornecedor { get; set; }

    public virtual ICollection<ItemVenda> ItemVenda { get; set; } = new List<ItemVenda>();

    public virtual ICollection<MovimentacaoEstoque> MovimentacaoEstoques { get; set; } = new List<MovimentacaoEstoque>();
}