namespace codeChallenge.Domain.Entities
{
    public class CoverageArea
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }

        public ICollection<Coordinates> Coordinates { get; set; }
    }
}