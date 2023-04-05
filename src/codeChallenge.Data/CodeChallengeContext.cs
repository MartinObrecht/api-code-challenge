using codeChallenge.Data.Models;
using codeChallenge.Domain.Entities;
using codeChallenge.Domain.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace codeChallenge.Data
{
    public class CodeChallengeContext : ICodeChallengeContext
    {
        private readonly IMongoCollection<Partner> _partnersCollection;

        public CodeChallengeContext(IOptions<ChallengeDatabaseSettings> challengeDatabaseSettings)
        {
            var mongoClient = new MongoClient(challengeDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(challengeDatabaseSettings.Value.DatabaseName);

            _partnersCollection = mongoDatabase.GetCollection<Partner>(challengeDatabaseSettings.Value.PartnersCollectionName);

        }

        public IMongoCollection<Partner> Partners => _partnersCollection;
    }
}