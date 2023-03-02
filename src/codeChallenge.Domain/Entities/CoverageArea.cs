namespace codeChallenge.Domain.Entities
{
    public class CoverageArea
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Coordinates { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; }

    }
}