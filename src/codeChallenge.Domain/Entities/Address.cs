namespace codeChallenge.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
    }
}