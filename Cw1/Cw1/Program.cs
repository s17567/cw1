using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Cw1
{
    class Program
    {

        public static async Task Main ( string[] args)
        {



            
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(args[0]);
           string response_string= await httpClient.GetStringAsync(args[0]);
            Console.WriteLine(response.StatusCode);
       //    Console.WriteLine(response_string);


            Regex email = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase );


           MatchCollection wyniki = email.Matches(response_string);


            Console.WriteLine(wyniki.Count);

            foreach ( Match match in wyniki)
            {
                Console.WriteLine(match.Value.ToString());
                
            }


        }
    }
}
