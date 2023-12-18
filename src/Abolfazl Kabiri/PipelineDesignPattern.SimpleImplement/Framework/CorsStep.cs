using Dumpify;
using PipelineDesignPattern.SimpleImplement.Pipeline;

namespace PipelineDesignPattern.SimpleImplement.Framework
{
    internal class CorsStep : IPipelineStep
    {
        public void Exceute(IPoplineContext context, Func<IPoplineContext, bool> func)
        {
            "Starting cors".Dump();
            func(context);
            "End cors".Dump();
        }
    }
}
