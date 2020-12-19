using System;
using System.ComponentModel.DataAnnotations;

namespace algorithon_server.Models
{
    public class JdoodleRequest
    {
        [Required]
        public String Lang { get; set; }
        
        [Required]
        public String Index { get; set; }
        
        [Required]
        public String Program {get; set; }
    }
}