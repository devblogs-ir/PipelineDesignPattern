using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace PipelineDesignPattern.Pipes
{
    public class AuthenticationPipe : Pipe
    {
        public AuthenticationPipe(Action<HTTPContext> next) : base(next)
        {

        }
        public override void Handle(HTTPContext hTTPContext)
        {
            "Starting Authentication...".Dump();
            
            "Authentication Operation ends here!".Dump();
            if (_next is not null)
                _next(hTTPContext);
        }
    }
}
