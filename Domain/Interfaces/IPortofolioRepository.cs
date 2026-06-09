using PortfolioManagement.Domain.Entities;

namespace PortfolioManagement.Domain.Interfaces
{
    public interface IPortofolioRepository : IRepository<Portofolio>
    {
        Task<IEnumerable<Portofolio>> GetPortofolioWithAssetsAsync(string userId);
        Task<Portofolio?> GetPortofolioWithAsasetsByIdAsync(Guid id, string userId);
    }
}
