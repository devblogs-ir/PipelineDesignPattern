using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    public class Framework
    {

        public void ExceptionHandling(HTTPContext http, Action<HTTPContext> exeptionAction)
        {
            "considering IP Address...".Dump();
            Thread.Sleep(2000);
            try
            {
                if (http.IP == "iran")
                    throw new Exception("Service to your location is not possible now!");
                else
                    exeptionAction(http);
            }
            catch (Exception ex)
            {
                ex.Message.Dump();
            }
        }
        public void AuthenticationHandling(HTTPContext http, Action<HTTPContext> authAction)
        {
            "Starting Authentication by userId...".Dump();
            if (http.UserId == 1)
            {
                "user is loged in".Dump();
                authAction(http);
            }
            else
            {
                "Go to Log In Page!".Dump();
            }

        }

        public void RoutingHandling(HTTPContext context, Action<HTTPContext> routingAction)
        {
                routingAction(context);
        }
    }
}
