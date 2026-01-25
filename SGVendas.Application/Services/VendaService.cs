using SGVendas.Application.DTOs;
using SGVendas.Application.Interfaces;




namespace SGVendas.Application.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaCommandRepository _command;

        public VendaService(IVendaCommandRepository command)
        {
            _command = command;
        }

        public async Task<int> CriarVendaAsync(CriarVendaDto dto)
        {
            if (!dto.Itens.Any())
                throw new Exception("Venda sem itens.");

            if (dto.TipoPagamento == "parcelado" && !dto.Parcelas.Any())
                throw new Exception("Parcelamento inválido.");

            return await _command.RegistrarVendaAsync(dto);
        }
    }
}
