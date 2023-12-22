using Dumpify;
using PipelineDesignPattern.SimpleImplement.Pipeline;

namespace PipelineDesignPattern.SimpleImplement.Framework;

public class AuthenticationStep<T> : IEndPointPipelineStep<T>
{
    public Func<T> Func { get; set; }
    public void Exceute(IPipelineContext context)
    {
        "Starting auth".Dump();
        Common.ValidateIpAddress(context);
        Func();
        "End auth".Dump();
    }

}
