using AutoMapper;
using PortfolioManagement.Application.DTOs;
using PortfolioManagement.Domain.Entities;

namespace PortfolioManagement.Application.Mappings
{
    public class PortofolioProfile : Profile
    {
        public PortofolioProfile()
        {
            CreateMap<Asset, AssetDto>();

            CreateMap<Portofolio, PortofolioDto>()
                .ForMember(dest => dest.TotalValue, opt => opt.MapFrom(src => src.GetTotalValue()));
        }
    }
}
