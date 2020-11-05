using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
   public class Program
    {
      private  static async Task Main(string[] args)
        {
            if (args.Length==0)
            {

                throw new ArgumentNullException("Tou have to pass to URL as first parameter.");

            }
            /// czy url poprawny
            /// 
          


bool result = Uri.TryCreate(args[0], UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttps || uriResult.Scheme == Uri.UriSchemeHttp);
            if (!result)
            { 

                throw new ArgumentException("url is not correct");

            }
         using   var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(args[0]);

            Console.WriteLine(uriResult);


            if (response.StatusCode == HttpStatusCode.OK)

               
            {
                string content = await response.Content.ReadAsStringAsync();
                Regex telRegex = new Regex(" [a-z]+@[a-z.]+");

                //  Console.WriteLine(content);
                MatchCollection matches = telRegex.Matches(content);

                HashSet<object> brak_duplikatu = new HashSet<object>();


                foreach(var m in matches)
                {

                     brak_duplikatu.Add(m);
                   // Console.WriteLine(m);

                }
foreach(var m in brak_duplikatu)
                {
                    Console.WriteLine(m);


                }

            }
            else
            {
                Console.WriteLine("nie pobrana strona ;c");
            }




        }
    }
}
