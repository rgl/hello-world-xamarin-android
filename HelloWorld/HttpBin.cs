using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HelloWorld
{
    internal class HttpBin
    {
        private class IpResponse
        {
            public string Origin { get; set; }
        }

        public static async Task<string> GetIp()
        {
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.ExpectContinue = false;

                var response = await http.GetAsync("http://httpbin.org/ip");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var ipResponse = JsonConvert.DeserializeObject<IpResponse>(json);

                return ipResponse.Origin;
            }
        }
    }
}
