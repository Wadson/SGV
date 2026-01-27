using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;
using SGVendas.Application.Interfaces.Services;
using SGVendas.Domain.Entities;

namespace SGVendas.Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _repository;

        public EmpresaService(IEmpresaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<EmpresaDto> Listar(string? filtro)
        {
            var query = _repository.Listar();

            if (!string.IsNullOrWhiteSpace(filtro))
                query = query.Where(e =>
                    e.RazaoSocial.Contains(filtro) ||
                    (e.NomeFantasia != null && e.NomeFantasia.Contains(filtro)));

            return query.Select(e => new EmpresaDto
            {
                EmpresaID = e.EmpresaID,
                RazaoSocial = e.RazaoSocial,
                NomeFantasia = e.NomeFantasia,
                CNPJ = e.CNPJ,
                Telefone = e.Telefone,
                Email = e.Email,
                Cidade = e.Cidade,
                UF = e.UF
            });
        }

        public EmpresaDto ObterPorId(int id)
        {
            var e = _repository.ObterPorId(id)
                ?? throw new Exception("Empresa não encontrada");

            return new EmpresaDto
            {
                EmpresaID = e.EmpresaID,
                RazaoSocial = e.RazaoSocial,
                NomeFantasia = e.NomeFantasia,
                CNPJ = e.CNPJ,
                InscricaoEstadual = e.InscricaoEstadual,
                InscricaoMunicipal = e.InscricaoMunicipal,
                CNAE = e.CNAE,
                Logradouro = e.Logradouro,
                Numero = e.Numero,
                Bairro = e.Bairro,
                Cep = e.Cep,
                Cidade = e.Cidade,
                UF = e.UF,
                Telefone = e.Telefone,
                Email = e.Email,
                Site = e.Site,
                Responsavel = e.Responsavel
            };
        }

        public void Criar(EmpresaDto dto)
        {
            _repository.Criar(new Empresa
            {
                RazaoSocial = dto.RazaoSocial,
                NomeFantasia = dto.NomeFantasia,
                CNPJ = dto.CNPJ,
                InscricaoEstadual = dto.InscricaoEstadual,
                InscricaoMunicipal = dto.InscricaoMunicipal,
                CNAE = dto.CNAE,
                Logradouro = dto.Logradouro,
                Numero = dto.Numero,
                Bairro = dto.Bairro,
                Cep = dto.Cep,
                Cidade = dto.Cidade,
                UF = dto.UF,
                Telefone = dto.Telefone,
                Email = dto.Email,
                Site = dto.Site,
                Responsavel = dto.Responsavel,
                DataCriacao = DateTime.UtcNow
            });
        }

        public void Atualizar(int id, EmpresaDto dto)
        {
            var empresa = _repository.ObterPorId(id)
                ?? throw new Exception("Empresa não encontrada");

            empresa.RazaoSocial = dto.RazaoSocial;
            empresa.NomeFantasia = dto.NomeFantasia;
            empresa.CNPJ = dto.CNPJ;
            empresa.InscricaoEstadual = dto.InscricaoEstadual;
            empresa.InscricaoMunicipal = dto.InscricaoMunicipal;
            empresa.CNAE = dto.CNAE;
            empresa.Logradouro = dto.Logradouro;
            empresa.Numero = dto.Numero;
            empresa.Bairro = dto.Bairro;
            empresa.Cep = dto.Cep;
            empresa.Cidade = dto.Cidade;
            empresa.UF = dto.UF;
            empresa.Telefone = dto.Telefone;
            empresa.Email = dto.Email;
            empresa.Site = dto.Site;
            empresa.Responsavel = dto.Responsavel;
            empresa.DataAtualizacao = DateTime.UtcNow;

            _repository.Atualizar(empresa);
        }

        public void Excluir(int id)
        {
            _repository.Excluir(id);
        }
    }
}
