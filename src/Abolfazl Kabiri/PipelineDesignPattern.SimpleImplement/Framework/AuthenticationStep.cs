using Dumpify;
using PipelineDesignPattern.SimpleImplement.Pipeline;

namespace PipelineDesignPattern.SimpleImplement.Framework
{
    internal class AuthenticationStep : IPipelineStep
    {
        public void Exceute(IPoplineContext context, Func<IPoplineContext, bool> func)
        {
            "Starting auth".Dump();
            func(context);
            "End auth".Dump();
        }
    }
}
