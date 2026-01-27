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

        public IEnumerable<ProdutoDto> Listar()
        {
            return _repository.Listar()
                .Select(p => MapToDto(p));
        }

        public ProdutoDto? ObterPorId(int id)
        {
            var produto = _repository.ObterPorId(id);
            return produto == null ? null : MapToDto(produto);
        }

        public void Criar(ProdutoDto dto)
        {
            var produto = MapToEntity(dto);
            _repository.Add(produto);
        }

        public void Atualizar(int id, ProdutoDto dto)
        {
            var produto = _repository.ObterPorId(id);
            if (produto == null)
                throw new Exception("Produto não encontrado");

            AtualizarEntity(produto, dto);
            _repository.Atualizar(produto);
        }

        public void Excluir(int id)
        {
            _repository.Excluir(id);
        }

        public IEnumerable<ProdutoDto> BuscarProdutos(string termo)
        {
            return _repository.BuscarProdutos(termo)
                .Select(p => new ProdutoDto
                {
                    ProdutoID = p.ProdutoID,
                    NomeProduto = p.NomeProduto,
                    PrecoDeVenda = p.PrecoDeVenda,
                    Estoque = p.Estoque
                });
        }

        // 🔽 Mapeamentos (sem AutoMapper por enquanto)

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
