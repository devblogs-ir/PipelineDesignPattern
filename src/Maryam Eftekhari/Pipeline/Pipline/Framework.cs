using Dumpify;
using System.Net;
using Pipeline.Context;
using Pipeline.Models;
using Pipeline.Exceptions;

namespace Pipeline
{
    public class FrameWork
    {
        public void Athentication(HttpContext context, Action<HttpContext> action)
        {            
            "Starting authenticate".Dump();

            string info = new WebClient().DownloadString(Constants.IP_SERVICE + context.IP);
            Thread.Sleep(5000);
            var ipInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<IpInfo>(info)!;
            if (ipInfo!.country != null && ipInfo.country == Constants.DENIDED_COUNTRY_NAME)
            {
                throw new DeniedIPException();
            }

            action(context);
            "Ending authenticate".Dump();
        }

        public void ExceptionHandling(HttpContext context, Action<HttpContext> action)
        {
            try
            {
                "Starting exception handling".Dump();
                action(context);
            }
            catch(DeniedIPException ex) 
            {
                ex.Message.Dump();
            }
            catch (Exception ex) 
            {
                ex.Message.Dump();
            }

            "Ending exception handling".Dump();
        }

        public void Cors(HttpContext context, Action<HttpContext> action)
        {
            "Starting cors".Dump();
            action(context);
            "Starting cors".Dump();
        }

        public void Routing(HttpContext context, Action<HttpContext> action)
        {
            "Starting routing".Dump();
            action(context);
            "Ending routing".Dump();
        }
    }
}