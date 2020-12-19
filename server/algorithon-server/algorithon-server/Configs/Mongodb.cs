using MongoDB.Driver;

namespace algorithon_server.Configs
{
    public class Mongodb
    {
        private string name { set; get; }
        private string password { set; get; }
        public MongoClient client { set; get; }
        public Mongodb()
        {
            this.name = "a100algorithon";
            this.password = "a100algorithon";
            this.client = new MongoClient($"mongodb+srv://{this.name}:{this.password}@a100.mzhl3.mongodb.net/A100?retryWrites=true&w=majority");
        }
    }
}