using System.Collections.Generic;
using System.Threading.Tasks;
using algorithon_server.Configs;
using algorithon_server.Interfaces;
using algorithon_server.Models;
using MongoDB.Driver;

namespace algorithon_server.Services
{
    public class ChallengeService : IChallengeService
    {
        
        private readonly IMongoCollection<Challenge> _challenge;
        //
        public ChallengeService()
        {
            Mongodb db = new Mongodb();
            _challenge = db.client.GetDatabase("dotnet-algo").GetCollection<Challenge>("challenge");
        }
        
        public async Task<List<Challenge>> Get()
        {
            return _challenge.Find(FilterDefinition<Challenge>.Empty).ToListAsync().Result;
        }

        public async Task<Challenge> Create(Challenge challenge)
        {
            await _challenge.InsertOneAsync(challenge);
            return challenge;
        }
    }
}