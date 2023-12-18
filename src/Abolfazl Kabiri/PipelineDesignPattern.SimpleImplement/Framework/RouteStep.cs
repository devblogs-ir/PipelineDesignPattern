using Dumpify;
using PipelineDesignPattern.SimpleImplement.Pipeline;

namespace PipelineDesignPattern.SimpleImplement.Framework
{
    internal class RouteStep : IPipelineStep
    {
        public void Exceute(IPoplineContext context, Func<IPoplineContext, bool> func)
        {
            "Starting route".Dump();
            func(context);
            "End route".Dump();
        }
    }
}
