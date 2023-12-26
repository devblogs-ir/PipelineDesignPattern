using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern.Pipes
{
    public abstract class Pipe
    {
        public Action<HTTPContext> _next;

        public Pipe(Action<HTTPContext> next)
        {
            _next = next;
        }
        public abstract void Handle(HTTPContext hTTPContext);
    }
}
