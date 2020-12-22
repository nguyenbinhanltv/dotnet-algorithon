using System.Collections.Generic;
using System.Threading.Tasks;
using algorithon_server.Models;

namespace algorithon_server.Interfaces
{
    public interface IChallengeService
    {
        Task<List<Challenge>> Get();

        Task<Challenge> Create(Challenge challenge);
    }
}