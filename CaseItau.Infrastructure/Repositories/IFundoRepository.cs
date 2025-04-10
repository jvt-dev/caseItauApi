using System.Collections.Generic;
using System.Threading.Tasks;
using CaseItau.API.Domain.Entities;

namespace CaseItau.API.Infrastructure.Repositories
{
    public interface IFundoRepository
    {
        Task<int> CreateAsync(FundoEntity entity);
        Task<int> UpdateAsync(FundoEntity entity);
        Task<int> DeleteAsync(FundoEntity entity);
        Task<FundoEntity> GetEntityByIdAsync(string codigo);
        Task<List<FundoEntity>> GetAllAsync();
    }
}
