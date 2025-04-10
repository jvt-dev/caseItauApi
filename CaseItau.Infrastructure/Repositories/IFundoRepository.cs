using System.Collections.Generic;
using System.Threading.Tasks;
using CaseItau.API.Domain.Entities;

namespace CaseItau.API.Infrastructure.Repositories
{
    public interface IFundoRepository
    {
        Task CreateAsync(FundoEntity entity);
        Task UpdateAsync(FundoEntity entity);
        Task DeleteAsync(FundoEntity entity);
        Task<FundoEntity> GetEntityById(string codigo);
        Task<List<FundoEntity>> GetAll();
    }
}
