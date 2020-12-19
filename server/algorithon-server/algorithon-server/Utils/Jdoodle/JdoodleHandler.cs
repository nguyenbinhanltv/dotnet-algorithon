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
            HttpClient http = new HttpClient();
            var path = "https://api.jdoodle.com/execute";
            Console.WriteLine(path);
            
            this._data.language = lang;
            this._data.versionIndex = index;
            this._data.script = program;
            this._data.clientId = "c134cb026eddc64eb67763eac076107f";
            this._data.clientSecret = "ba9217cb231136b86118ee9ad0cc878c0391dfbfe359d34d7907b3f36c6b20c3";
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