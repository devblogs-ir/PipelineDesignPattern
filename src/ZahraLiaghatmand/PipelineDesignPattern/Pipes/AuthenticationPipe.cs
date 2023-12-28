using PipelineDesignPattern.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern.Pipes
{
    public class AuthenticationPipe : Pipe
    {
        public AuthenticationPipe() : base()
        {
            _next = null!;
        }
        public AuthenticationPipe(Action<HttpContext> next)
        {
            _next = next;
        }
        Action<HttpContext> _next;
        public override void Handle(HttpContext httpContext)
        {
            Console.WriteLine("starting Auth...");
            if (httpContext is null)
                throw new IPNotProvideException("IP is not provided");
            else if (httpContext.IP is "85.185.20.177")
                throw new InvalidIPException("invalid IP");

            if (_next != null)
                _next(httpContext);
        }
    }
}
