using System.Collections.Generic;
using System.Threading.Tasks;
using CaseItau.API.Entities;

namespace CaseItau.API.Application.Repositories
{
    public interface IFundoRepository
    {
        Task PostAsync(FundoEntity entity);
        Task PutAsync(FundoEntity entity);
        Task DeleteAsync(FundoEntity entity);
        Task<FundoEntity> GetEntityById(string codigo);
        Task<List<FundoEntity>> GetAll();
    }
}
