using CaseItau.API.Domain.Entities;
using CaseItau.API.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.Infrastructure.Repositories
{
    public class TipoFundoRepository : ITipoFundoRepository
    {
        private readonly FundoContext _context;

        public TipoFundoRepository(FundoContext context)
        {
            _context = context;
        }

        public async Task<List<TipoFundoEntity>> GetAllAsync()
        {
            return await _context.Set<TipoFundoEntity>().ToListAsync();
        }
    }
}
