namespace codeChallenge.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<double> Coordinates { get; set; }
    }
}