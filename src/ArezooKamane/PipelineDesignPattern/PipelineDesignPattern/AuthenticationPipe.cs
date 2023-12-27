using Dumpify;

namespace PipelineDesignPattern;

    public class AuthenticationPipe : BasePipe
    {
        public AuthenticationPipe(Action<HttpContext> next) : base(next){}
        public override void Invoke(HttpContext context)
        {
            "Start authenticate user".Dump();

            if (IpRangeChecker.IpRangeCheck(context.IP))
                throw new IpNotAllowedException(ip: context.IP);
            else
                if(Next is not null ) Next(context);

            "End of authenticate user".Dump();
        }
    }

