namespace codeChallenge.Domain.Entities
{
    public class Coordinates
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitute { get; set; }
        public int CoverageAreaId { get; set; }
        public CoverageArea CoverageArea { get; set; }
    }
}