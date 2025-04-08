using System.Collections.Generic;
using System.Threading.Tasks;
using CaseItau.API.Entities;
using CaseItau.API.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CaseItau.API.Application.Repositories
{
    public class FundoRepository : IFundoRepository
    {
        private readonly FundoContext _context;

        public FundoRepository(FundoContext context)
        {
            _context = context;
        }

        public async Task PostAsync(FundoEntity entity)
        {
            await _context.Set<FundoEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task PutAsync(FundoEntity entity)
        {
            _context.Set<FundoEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(FundoEntity entity)
        {
            _context.Set<FundoEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<FundoEntity> GetEntityById(string id)
        {
            return await _context.Set<FundoEntity>().FindAsync(id);
        }

        public async Task<List<FundoEntity>> GetAll()
        {
            return await _context.Set<FundoEntity>().ToListAsync();
        }
    }
}
