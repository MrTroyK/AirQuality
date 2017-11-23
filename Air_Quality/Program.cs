using System;
using System.Net;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace AirQuality
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            String ip, pos;

            ip = GetMyIP();
            pos = GetLocalizeIP(ip);
            Console.WriteLine($"{ip}:\n{pos}\n");

            dynamic loc = JsonConvert.DeserializeObject<dynamic>(pos);

            Console.WriteLine($"City\t    : {loc.city}");
            Console.WriteLine($"Country \t: {loc.country}");
            Console.WriteLine($"ISP\t     : {loc.isp}");
            Console.WriteLine($"GPS\t     : ({loc.lat}, {loc.lon})");
        }


        static string GetLocalizeIP(string ip)
        {
            WebClient webclient;
            string res, url;

            webclient = new WebClient();
            url = string.Format("http://ip-api.com/json/{0}", ip);
            res = webclient.DownloadString(url);
            res = res.Trim();

            return res;
        }

        static string GetMyIP()
        {
            WebClient webClient;
            string res;

            webClient = new WebClient();

            res = webClient.DownloadString("http://icanhazip.com");
            res = res.Trim();

            return res;
        }
    }
}
