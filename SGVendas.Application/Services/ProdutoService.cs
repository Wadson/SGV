using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;
using SGVendas.Domain.Entities;

namespace SGVendas.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        // 📄 LISTAGEM
        public IEnumerable<ProdutoDto> Listar()
        {
            return _repository.Listar()
                .Select(MapToDto);
        }

        // 🔎 PESQUISA PARCIAL (TELA DE PRODUTOS)
        public IEnumerable<ProdutoDto> Pesquisar(string termo)
        {
            var query = _repository.Query();

            if (!string.IsNullOrWhiteSpace(termo))
            {
                termo = termo.Trim();

                query = query.Where(p =>
                    p.NomeProduto.Contains(termo) ||
                    (p.Referencia != null && p.Referencia.Contains(termo)) ||
                    (p.GtinEan != null && p.GtinEan.Contains(termo))
                );
            }

            return query
                .Select(p => new ProdutoDto
                {
                    ProdutoID = p.ProdutoID,
                    NomeProduto = p.NomeProduto,
                    PrecoDeVenda = p.PrecoDeVenda,
                    Estoque = p.Estoque,
                    Status = p.Status
                })
                .ToList(); // ✅ EXECUTA SÓ AQUI
        }


        // 🔍 AUTOCOMPLETE (VENDA)
        public IEnumerable<Produto> BuscarProdutos(string termo)
        {
            return _repository.BuscarProdutos(termo);
        }

        // 🔎 OBTER POR ID
        public ProdutoDto? ObterPorId(int id)
        {
            var produto = _repository.ObterPorId(id);
            return produto == null ? null : MapToDto(produto);
        }

        // ➕ CRIAR
        public void Criar(ProdutoDto dto)
        {
            var produto = new Produto
            {
                NomeProduto = dto.NomeProduto,
                Referencia = dto.Referencia,

                // ✔ CAMPOS OBRIGATÓRIOS (NUNCA PODEM FICAR NULOS)
                PrecoCusto = dto.PrecoCusto > 0 ? dto.PrecoCusto : 0,
                Lucro = dto.Lucro > 0 ? dto.Lucro : 0,
                PrecoDeVenda = dto.PrecoDeVenda,

                Estoque = dto.Estoque,
                DataDeEntrada = DateTime.Now,

                Status = string.IsNullOrWhiteSpace(dto.Status)
                            ? "Ativo"
                            : dto.Status,

                Situacao = dto.Situacao,
                Unidade = dto.Unidade,
                Marca = dto.Marca,
                DataValidade = dto.DataValidade,
                GtinEan = dto.GtinEan,
                Imagem = dto.Imagem,
                FornecedorID = dto.FornecedorID
            };

            _repository.Add(produto);
        }


        // ✏️ ATUALIZAR
        public void Atualizar(int id, ProdutoDto dto)
        {
            var produto = _repository.ObterPorId(id);
            if (produto == null)
                throw new Exception("Produto não encontrado");

            // ✔ Atualiza SOMENTE o que vem da tela
            produto.NomeProduto = dto.NomeProduto;
            produto.Referencia = dto.Referencia;
            produto.PrecoDeVenda = dto.PrecoDeVenda;
            produto.Estoque = dto.Estoque;
            produto.Status = dto.Status;
            produto.Unidade = dto.Unidade;
            produto.Marca = dto.Marca;
            produto.DataValidade = dto.DataValidade;
            produto.Situacao = dto.Situacao;
            produto.GtinEan = dto.GtinEan;
            produto.Imagem = dto.Imagem;

            // ❗ NÃO mexe nesses campos:
            // produto.PrecoCusto
            // produto.Lucro
            // produto.DataDeEntrada

            _repository.Atualizar(produto);
        }


        // ❌ EXCLUIR
        public void Excluir(int id)
        {
            _repository.Excluir(id);
        }


        // =========================
        // 🔽 MAPEAMENTOS MANUAIS
        // =========================

        private static ProdutoDto MapToDto(Produto p) => new()
        {
            ProdutoID = p.ProdutoID,
            NomeProduto = p.NomeProduto,
            Referencia = p.Referencia,
            PrecoCusto = p.PrecoCusto,
            Lucro = p.Lucro,
            PrecoDeVenda = p.PrecoDeVenda,
            Estoque = p.Estoque,
            Status = p.Status,
            Unidade = p.Unidade,
            Marca = p.Marca,
            DataValidade = p.DataValidade
        };

        private static Produto MapToEntity(ProdutoDto dto) => new()
        {
            NomeProduto = dto.NomeProduto,
            Referencia = dto.Referencia,
            PrecoCusto = dto.PrecoCusto,
            Lucro = dto.Lucro,
            PrecoDeVenda = dto.PrecoDeVenda,
            Estoque = dto.Estoque,
            DataDeEntrada = DateTime.Now,
            Status = dto.Status ?? "Disponível",
            Unidade = dto.Unidade,
            Marca = dto.Marca,
            DataValidade = dto.DataValidade,
            FornecedorID = dto.FornecedorID
        };

        private static void AtualizarEntity(Produto p, ProdutoDto dto)
        {
            p.NomeProduto = dto.NomeProduto;
            p.Referencia = dto.Referencia;
            p.PrecoCusto = dto.PrecoCusto;
            p.Lucro = dto.Lucro;
            p.PrecoDeVenda = dto.PrecoDeVenda;
            p.Estoque = dto.Estoque;
            p.Status = dto.Status!;
            p.Unidade = dto.Unidade;
            p.Marca = dto.Marca;
            p.DataValidade = dto.DataValidade;
            p.FornecedorID = dto.FornecedorID;
        }
    }
}
