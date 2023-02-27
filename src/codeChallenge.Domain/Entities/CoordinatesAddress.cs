namespace codeChallenge.Domain.Entities
{
    public class CoordinatesAddress
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitute { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}