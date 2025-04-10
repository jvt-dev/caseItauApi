using CaseItau.API.Domain.Entities;
using CaseItau.API.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.API.Infrastructure.Repositories
{
    public class FundoRepository : IFundoRepository
    {
        private readonly FundoContext _context;

        public FundoRepository(FundoContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(FundoEntity entity)
        {
            await _context.Set<FundoEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FundoEntity entity)
        {
            _context.Set<FundoEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(FundoEntity entity)
        {
            _context.Set<FundoEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<FundoEntity> GetEntityById(string codigo)
        {
            return await _context.Set<FundoEntity>().FindAsync(codigo);
        }

        public async Task<List<FundoEntity>> GetAll()
        {
            return await _context.Set<FundoEntity>().ToListAsync();
        }
    }
}
