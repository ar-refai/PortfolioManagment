namespace PortfolioManagement.Domain.Entities
{
    public class Portfolio
    {
        public Guid Id { get; private set; }
        public string UserId { get; private set; }
        public string Name { get; private set; }

        private readonly List<Asset> _assets = new();

        public IReadOnlyCollection<Asset> Assets => _assets.AsReadOnly();

        private Portfolio() { }
        public Portfolio(string userId, string name)
        {
            if (string.IsNullOrEmpty(userId)) throw new ArgumentNullException("You must provide user id");
            Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
        }

        public void AddAsset(Asset asset)
        {
            // check if we already have this ticker 
            var existingAsset = _assets.FirstOrDefault(a => a.TickerSymbol == asset.TickerSymbol);
            if(existingAsset != null)
            {
                existingAsset.AddQuantity(asset.Quantity);
                existingAsset.UpdatePrice(asset.CurrentPrice);
            }
            else
            {
                _assets.Add(asset);
            }
        }

        public decimal GetTotalValue()
        {
            return _assets.Sum(a => a.Quantity * a.CurrentPrice);
        }
    }
}
