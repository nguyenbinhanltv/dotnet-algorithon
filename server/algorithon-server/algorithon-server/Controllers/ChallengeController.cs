using algorithon_server.Interfaces;
using algorithon_server.Models;
using Microsoft.AspNetCore.Mvc;

namespace algorithon_server.Controllers
{
    [ApiController]
    [Route("challenge")]
    public class ChallengeController : ControllerBase
    {
        private IChallengeService _challengeService;

        public ChallengeController(IChallengeService challengeService)
        {
            _challengeService = challengeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_challengeService.Get());
        }

        [HttpPost]
        public IActionResult Create(Challenge challenge)
        {
            _challengeService.Create(challenge);
            return Ok();
        }
    }
}