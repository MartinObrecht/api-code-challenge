using codeChallenge.Domain.Entities;
using MongoDB.Driver;

namespace codeChallenge.Domain.Interfaces
{
    public interface ICodeChallengeContext
    {
        IMongoCollection<Partner> Partners { get; }
    }
}