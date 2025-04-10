using CaseItau.API.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.Application.Services
{
    public interface IFundoService
    {
        Task<IEnumerable<FundoDto>> GetAllAsync();
        Task<FundoDto> GetAsync(string codigo);
        Task PostAsync(FundoDto dto);
        Task PutAsync(string codigo, FundoDto dto);
        Task DeleteAsync(string codigo);
        Task MovimentarPatrimonioAsync(string codigo, decimal valorPatrimonio);
    }
}
