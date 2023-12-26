using Dumpify;
using PipelineDesignPattern.SimpleImplement.Pipeline;

namespace PipelineDesignPattern.SimpleImplement.Framework;

public class AuthenticationStep : IPipe
{
    public Action<IPipelineContext> Next { get; set; }
    public void Invoke(IPipelineContext context)
    {
        "Starting auth".Dump();
        Common.ValidateIpAddress(context);
        Next(context);
        "End auth".Dump();
    }
}
