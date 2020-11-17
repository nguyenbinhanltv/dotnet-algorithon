using System;
using System.Collections.Generic;
using algorithon_server.Models;
using Microsoft.AspNetCore.Mvc;

namespace algorithon_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguagesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Language[]> Get()
        {
            return;
        }
    }
}