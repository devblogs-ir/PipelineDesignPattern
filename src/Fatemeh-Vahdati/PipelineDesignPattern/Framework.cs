using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    internal class Framework
    {
        public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
        {
            try
            {
                action(httpContext);
                Console.WriteLine("Authentication was successful");
            }
            catch (Exception ex) 
            {

                Console.WriteLine("Authentication was unsuccessful: " + ex.Message);
            }

        }

        public void AuthenticationHandling(HttpContext httpContext, Action<HttpContext> action)
        {
            Console.WriteLine($"Start Authentication For IP : {httpContext.IP}");
            if (CheckCountryName(httpContext.IP) == "iran")
                throw new Exception("Your request failed because you are from Iran.");

            action(httpContext);
            

        }

        string CheckCountryName(string IP)
        {
            HttpService httpService = new();
            var result = httpService.GetAsync($"http://api.ipstack.com/{IP}?access_key=9a292115e7fe1aa9bc9155c5b2d0df3c");
            if (result.Result == null)
            {
                return "";
            }
            var d = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(result.Result);
            return d["country_name"].ToString().ToLower();
             

        }
    }
}
