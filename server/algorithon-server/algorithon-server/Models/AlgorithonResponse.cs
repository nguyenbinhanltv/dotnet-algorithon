using System;
using System.ComponentModel.DataAnnotations;

namespace algorithon_server.Models
{
    public class AlgorithonResponse
    {
        [Required]
        public String Message { get; set; }
        
        [Required]
        public String Error { get; set; }
        
        [Required]
        public Array Data {get; set; }
    }
}