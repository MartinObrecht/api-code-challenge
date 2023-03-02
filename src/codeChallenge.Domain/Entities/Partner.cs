namespace codeChallenge.Domain.Entities
{
    public class Partner
    {
        public int Id { get; set; }
        public string TradingName { get; set; }
        public string OwnerName { get; set; }
        public long Document { get; set; }
        public ICollection<CoverageArea> CoverageArea { get; set; }
        public Address Addres { get; set; }
    }
}