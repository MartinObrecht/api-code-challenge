namespace codeChallenge.Domain.Entities
{
    public class CoverageArea
    {
        public string Type { get; set; }
        public List<List<List<List<double>>>> Coordinates { get; set; }
    }
}