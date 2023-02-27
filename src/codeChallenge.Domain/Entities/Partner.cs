namespace codeChallenge.Domain.Entities
{
    public class Partner
    {
        public int Id { get; set; }
        public string TradingName { get; set; }
        public string OwnerName { get; set; }
        public string Document { get; set; }
        public int CoverageAreaId { get; set; }
        public CoverageArea CoverageArea { get; set; }
        public int AddressId { get; set; }
        public Address Addres { get; set; }
    }
}