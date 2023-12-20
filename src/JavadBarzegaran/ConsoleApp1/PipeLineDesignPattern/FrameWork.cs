using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineDesignPattern
{
    public class FrameWork
    {
        public void ExceptionHandling(HttpContext httpContext, Action<HttpContext> action)
        {
            try
            {
                action(httpContext);
                "Welcome,You Are From CANADA".Dump();
            }
            catch(Exception ex)
            {
                "Eror,You Are From Iran".Dump();
            }    
        }

        public void Authentication(HttpContext httpContext)
        {
            if (httpContext.UserIp.Equals("IRAN"))
            {
                throw new Exception();
            }
        }


    }
}
