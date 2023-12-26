using Dumpify;
using PipelineDesignPattern.SimpleImplement.Pipeline;

namespace PipelineDesignPattern.SimpleImplement.Framework;

public class AuthenticationPipe : IPipe
{
    public Action<IPipelineContext> Next { get; set; }
    public void Invoke(IPipelineContext context)
    {
        "Starting auth".Dump();
        Ip.IsValidate(context);
        Next(context);
        "End auth".Dump();
    }
}
