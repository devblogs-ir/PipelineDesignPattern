using Dumpify;
using PipelineDesignPattern.SimpleImplement.Pipeline;

namespace PipelineDesignPattern.SimpleImplement.Framework
{
    public class RouteStep : IPipelineStep
    {
        public Action<IPipelineContext> Action { get; set; }

        public void Exceute(IPipelineContext context)
        {
            "Starting route".Dump();
            Action(context);
            "End route".Dump();
        }
    }
}
