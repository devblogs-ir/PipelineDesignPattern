using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineDesignPattern
{
    public class Framework
    {
        public delegate void Action();

        public void ExceptionHandling(HttpContext context, Action<HttpContext> action)
        {
            try
            {
                action(context);
            }
            catch (Exception ex)
            {
                "IP banned".Dump(ex.Message);
            }
        }

        public void Authentication(HttpContext context, Action<HttpContext> action) 
        {
            if (context.IP == "10.10.1.1")
            {
                throw new Exception("You are from Iran");
            }
            action(context);
        }
    }
}
