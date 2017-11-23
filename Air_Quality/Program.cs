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
            String ip, pos, air_quality, lat, lon;

            ip = GetMyIP();
            pos = GetLocalizeIP(ip);
            Console.WriteLine($"{ip}:\n{pos}\n");

            dynamic loc = JsonConvert.DeserializeObject<dynamic>(pos);

            Console.WriteLine($"{ip} at {loc.city}/{loc.country} :\n${air_quality}");
        }

        static string GetAirQuality(string lat, string lon)
        {
            WebClient
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
