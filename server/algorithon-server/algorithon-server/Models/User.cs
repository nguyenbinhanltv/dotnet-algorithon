using System.Text.Json.Serialization;

namespace algorithon_server.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        [JsonIgnore]
        public string Password { get; set; }
    }
}