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

        public async Task<int> CreateAsync(FundoEntity entity)
        {
            await _context.Set<FundoEntity>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(FundoEntity entity)
        {
            _context.Set<FundoEntity>().Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(FundoEntity entity)
        {
            _context.Set<FundoEntity>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<FundoEntity> GetEntityByIdAsync(string codigo)
        {
            return await _context.Set<FundoEntity>().FindAsync(codigo);
        }

        public async Task<List<FundoEntity>> GetAllAsync()
        {
            return await _context.Set<FundoEntity>().ToListAsync();
        }
    }
}
