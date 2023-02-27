namespace codeChallenge.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }

        public ICollection<CoordinatesAddress> CoordinatesAddress { get; set; }
    }
}