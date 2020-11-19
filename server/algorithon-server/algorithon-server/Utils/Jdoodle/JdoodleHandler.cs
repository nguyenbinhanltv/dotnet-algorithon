using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace algorithon_server.Utils.Jdoodle
{
    public class JdoodleHandler
    {
        Data _data = new Data();

        public async Task<string> PostRunRequest(String lang,String index, String program)
        {
            DotNetEnv.Env.Load("../Configs/.env");
            HttpClient http = new HttpClient();
            var path = System.Environment.GetEnvironmentVariable("JDOODLE_ENDPOINT_EXECUTE");
            
            this._data.language = lang;
            this._data.versionIndex = index;
            this._data.script = program;
            this._data.clientId = System.Environment.GetEnvironmentVariable("JDOODLE_CLIENT_ID");
            this._data.clientSecret = System.Environment.GetEnvironmentVariable("JDOODLE_CLIENT_SECRET");
            var json = JsonConvert.SerializeObject(this._data);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

           
            var respose = await http.PostAsync(path, data);

            if (respose.IsSuccessStatusCode)
            {
                return respose.Content.ReadAsStringAsync().Result;
            }

            return null;
        }
    }

    public class Data
    {
        public String language { get; set; }
        public String versionIndex { get; set; }
        public String script { get; set; }
        public String clientId { get; set; }
        public String clientSecret { get; set; }
    }
}