namespace codeChallenge.Data.Models
{
    public class ChallengeDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PartnersCollectionName { get; set; } = null!;
    }
}