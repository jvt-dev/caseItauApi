using CaseItau.API.Application.Services.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.API.Application.Services
{
    public interface IFundoService
    {
        Task<IEnumerable<FundoModel>> GetAllAsync();
        Task<FundoModel> GetAsync(string codigo);
        Task PostAsync(FundoModel model);
        Task PutAsync(FundoModel model);
        Task DeleteAsync(string codigo);
    }
}
