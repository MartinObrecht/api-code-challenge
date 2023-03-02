namespace codeChallenge.Application.Handlers.V1.Partners.Create.Dtos
{
    public class CoverageAreaDto
    {
        public string Type { get; set; }
        public List<List<double>> Coordinates { get; set; }
    }
}