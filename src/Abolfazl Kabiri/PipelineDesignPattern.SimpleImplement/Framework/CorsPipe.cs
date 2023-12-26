using Dumpify;
using PipelineDesignPattern.SimpleImplement.Pipeline;

namespace PipelineDesignPattern.SimpleImplement.Framework;

public class CorsPipe : IPipe
{
    public Action<IPipelineContext> Next { get; set; }
    public void Invoke(IPipelineContext context)
    {
        "Starting cors".Dump();
        Next(context);
        "End cors".Dump();
    }
}
