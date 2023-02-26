namespace codeChallenge.Domain.Entities
{
    public class Partner
    {
        public int Id { get; set; }
        public string TradingName { get; set; }
        public string OwnerName { get; set; }
        public string Document { get; set; }
        public CoverageArea CoverageArea { get; set; }
        public Addres Addres { get; set; }
    }
}