using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Domain.Entities;
using PortfolioManagement.Domain.Interfaces;
using PortfolioManagement.Infrastructure.Data;

namespace PortfolioManagement.Infrastructure.Repositories
{
    public class PortofolioRepository : Repository<Portofolio>, IPortofolioRepository
    {
        public PortofolioRepository(AppDbContext context) : base(context)  { }

        public async Task<Portofolio?> GetPortofolioWithAsasetsByIdAsync(Guid id, string userId)
        {
            return await _context.Portfolios
                .Include(p => p.Assets)
                .FirstOrDefaultAsync( p => p.Id == id && p.UserId == userId);
        }

        public async Task<IEnumerable<Portofolio>> GetPortofolioWithAssetsAsync(string userId)
        {
            return await _context.Portfolios
                .AsNoTracking()
                .Include(p => p.Assets)
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }
    }
}
