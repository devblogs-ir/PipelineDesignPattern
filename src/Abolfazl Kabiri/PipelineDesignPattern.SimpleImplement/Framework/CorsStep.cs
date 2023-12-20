using Dumpify;
using PipelineDesignPattern.SimpleImplement.Pipeline;

namespace PipelineDesignPattern.SimpleImplement.Framework;

public class CorsStep : IPipelineStep
{
    public Action<IPipelineContext> Action { get; set; }
    public void Exceute(IPipelineContext context)
    {
        "Starting cors".Dump();
        Action(context);
        "End cors".Dump();
    }
}
