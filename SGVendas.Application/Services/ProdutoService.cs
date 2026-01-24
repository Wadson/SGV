using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;

namespace SGVendas.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProdutoDto> Buscar(string termo)
        {
            return _repository.Buscar(termo)
                .Select(p => new ProdutoDto
                {
                    ProdutoID = p.ProdutoID,
                    NomeProduto = p.NomeProduto,
                    PrecoDeVenda = p.PrecoDeVenda
                });
        }
    }
}
