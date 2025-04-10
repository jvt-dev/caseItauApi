using CaseItau.API.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.Application.Services
{
    public interface IFundoService
    {
        Task<IEnumerable<FundoDto>> GetAllAsync();
        Task<FundoDto> GetByIdAsync(string codigo);
        Task<bool> PostAsync(FundoDto dto);
        Task<bool> PutAsync(string codigo, FundoDto dto);
        Task<bool> DeleteAsync(string codigo);
        Task<bool> MovimentarPatrimonioAsync(string codigo, decimal valorPatrimonio);
    }
}
