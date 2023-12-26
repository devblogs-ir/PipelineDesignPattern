using Dumpify;
using PipelineDesignPattern.SimpleImplement.Pipeline;

namespace PipelineDesignPattern.SimpleImplement.Framework;

public class RoutePipe : IPipe
{
    public Action<IPipelineContext> Next { get; set; }
    public void Invoke(IPipelineContext context)
    {
        "Starting route".Dump();
        Next(context);
        "End route".Dump();
    }
}
