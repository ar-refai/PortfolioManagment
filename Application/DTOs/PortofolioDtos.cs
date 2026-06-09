namespace PortfolioManagement.Application.DTOs;

// incoming requests
public record class CreatePortofolioDto(string Name);

public record class AssetDto(string TickerSymbol, decimal Quantity, decimal CurrentPrice);

// outgoing requests
public record class PortofolioDto(Guid Id, string Name, decimal TotalValue, List<AssetDto> Assets);