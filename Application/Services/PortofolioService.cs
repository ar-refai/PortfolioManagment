using AutoMapper;
using PortfolioManagement.Application.DTOs;
using PortfolioManagement.Domain.Entities;
using PortfolioManagement.Domain.Interfaces;

namespace PortfolioManagement.Application.Services
{
    public class PortofolioService : IPortofolioService
    {
        private readonly IPortofolioRepository _portoRepo;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PortofolioService(IPortofolioRepository portoRepo, IUnitOfWork uow, IMapper mapper)
        {
            _portoRepo = portoRepo;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PortofolioDto> CreatePortofolioAsync(string userId, PortofolioDto dto)
        {

            var porto = new Portofolio(userId,dto.Name);
            await _portoRepo.AddAsync(porto);
            await _uow.SaveChangesAsync();
            return _mapper.Map<PortofolioDto>(porto);
        }

        public Task<IEnumerable<PortofolioDto>> GetUserPortofoliosAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
