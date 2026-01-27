using SGVendas.Domain.Entities;
public class Fornecedor
{
    public int FornecedorID { get; set; }

    public string Nome { get; set; } = null!;

    public string? Cnpj { get; set; }

    public string? IE { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public int CidadeID { get; set; }

    public string? Logradouro { get; set; }

    public string? Numero { get; set; }

    public string? Bairro { get; set; }

    public string? Cep { get; set; }

    public DateTime? DataCriacao { get; set; }

    public string? Observacoes { get; set; }

    public virtual Cidade Cidade { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
