using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace PipelineDesignPattern.Pipes
{
    public class LocationManagmentPipe : Pipe
    {
        public LocationManagmentPipe(Action<HTTPContext> next):base(next)
        {
            
        }
        public override void Handle(HTTPContext context)
        {
            "considering IP Address...".Dump();
            try
            {
                if (context.IP is "iran")
                {
                    throw new GeoLocationException(context.IP);
                }
                else if (_next is not null)
                    _next(context);
            }
            catch (GeoLocationException ex)
            {
                ex.Message.Dump();
            }
        }
    }
}
