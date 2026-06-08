using Microsoft.AspNetCore.Mvc.Formatters;

namespace PortfolioManagement.Domain.Entities
{
    public class Asset
    {
        public Guid Id { get; private set; }
        public string TickerSymbol { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal CurrentPrice { get; private set; }

        private Asset() { }
        public Asset(string tickerSymbol, decimal initialQuantity , decimal currentPrice)
        {
            if (string.IsNullOrEmpty(tickerSymbol))
                throw new ArgumentException("Ticker Symbol cannot be empty.");
            if (initialQuantity < 0)
                throw new ArgumentException("Initial Price cannot be negative");
            Id = Guid.NewGuid();
            TickerSymbol = tickerSymbol;
            Quantity = initialQuantity;
            CurrentPrice = currentPrice;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentException("New price cannot be negative");
                CurrentPrice = newPrice;
        }

        public void AddQuantity(decimal newQuantity)
        {
            if (newQuantity <= 0)
                throw new ArgumentException("New quantity cannot be negative or equal to zero");
            Quantity += newQuantity;
        }

    }
}
