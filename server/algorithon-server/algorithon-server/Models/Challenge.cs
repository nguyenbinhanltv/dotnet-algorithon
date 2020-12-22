using System.Collections.Generic;
using IdGen;

namespace algorithon_server.Models
{
    public class Challenge
    {
        public string Id = new IdGenerator(0).CreateId().ToString();
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public List<string> History { get; set; }
        
        public List<TestCase> TestCases { get; set; }
    }
}