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
            //Console.WriteLine($"{ip}:\n{pos}\n");

            dynamic loc = JsonConvert.DeserializeObject<dynamic>(pos);

            lat = loc.lat;
            lon = loc.lon;
            air_quality = GetAirQuality(lat, lon);

            dynamic quality = JsonConvert.DeserializeObject<dynamic>(air_quality);

            Console.WriteLine($"{ip} at {loc.city}/{loc.country} :\n{quality.country_description} {quality.dominant_polluant_description}");
        }

        static string GetAirQuality(string lat, string lon)
        {
            WebClient webclient;
            string res, url;

            webclient = new WebClient();
            url = $"https://api.breezometer.com/baqi/?lat={lat}&lon={lon}&key=3e3ca9627cd24faf8626cead119876ed";
            res = webclient.DownloadString(url);
            res = res.Trim();

            return res;
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
