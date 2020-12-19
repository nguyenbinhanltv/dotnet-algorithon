using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace algorithon_server.Models
{
    public class JdoodleResponse
    {
        [Required]
        public String Message { get; set; }
        
        [Required]
        public String Error { get; set; }
        
        [Required]
        public dynamic Data {get; set; }
    }
}