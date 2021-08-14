using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SendGrid;
namespace Tron
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Дай регистрационен номер ве:");
            var regNumber = Console.ReadLine();
            string json = new WebClient().DownloadString($"https://check.bgtoll.bg/check/vignette/plate/BG/" + regNumber);
            var items = JsonConvert.DeserializeObject<JSON>(json);
            if (items.Ok)
            {
                Console.WriteLine("ми да, имаш винетка");
            }
            else
            {
                Console.WriteLine("srry, нямаш винетка");
            }
        }
    }
}
