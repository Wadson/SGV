using SGVendas.Domain.Entities;
using SGVendas.Infra.Context;
using SGVendas.Application.Interfaces;

public class ClienteCadastroRepository : IClienteCadastroRepository
{
    private readonly SGVendasDbContext _context;

    public ClienteCadastroRepository(SGVendasDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Cliente> Listar()
        => _context.Clientes.OrderBy(c => c.Nome).ToList();

    public Cliente ObterPorId(int id)
        => _context.Clientes.Find(id);

    public void Criar(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
    }

    public void Atualizar(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
    }
}
