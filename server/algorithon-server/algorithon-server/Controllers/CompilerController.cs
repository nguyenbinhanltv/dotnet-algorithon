using System;
using System.Linq;
using System.Threading.Tasks;
using algorithon_server.Models;
using algorithon_server.Utils.Jdoodle;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace algorithon_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompilerController : ControllerBase
    {
        [HttpPost]
        public JdoodleResponse Run(JdoodleRequest body)
        {
            if (body == null || body.Index == null || body.Lang == null || body.Program == null)
            {
                return new JdoodleResponse()
                {
                    Error = "Body invalid",
                    Data = null,
                    Message = "Error"
                };
            }
            var jdoodle = new JdoodleHandler();
            var result = jdoodle.PostRunRequest(body.Lang, body.Index, body.Program);

            return new JdoodleResponse()
            {
                Error = null,
                Data = JsonConvert.SerializeObject(result.Result),
                Message = "OK"
            };
        }

        [HttpPost]
        [Route("submit-challenge")]
        public JdoodleResponse SubmitChallenge(dynamic body)
        {
            bool[] result = new bool[] {};
            foreach (var ts in body.TestCase)
            {
                string replaceProgram = body.Program.ToString().Replace("input", ts.Input);
                JdoodleRequest request = new JdoodleRequest()
                {
                    Index = body.Index,
                    Lang = body.Lang,
                    Program = replaceProgram
                };
                JdoodleResponse response = this.Run(request);
                if (response.Data)
                {
                    if (response.Data.Output == ts.Output)
                    {
                        result.ToList().Add(true);
                        result.ToArray();
                    }
                    else
                    {
                        result.ToList().Add(false);
                        result.ToArray();
                    }
                }
            }

            return new JdoodleResponse()
            {
                Error = null,
                Data = result,
                Message = "OK"
            };
        }
    }
}