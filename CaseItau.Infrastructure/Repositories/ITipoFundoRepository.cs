using CaseItau.API.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.Infrastructure.Repositories
{
    public interface ITipoFundoRepository
    {
        Task<List<TipoFundoEntity>> GetAllAsync();
    }
}
