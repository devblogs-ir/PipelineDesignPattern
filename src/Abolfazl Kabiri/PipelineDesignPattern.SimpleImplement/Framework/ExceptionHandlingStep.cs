using Dumpify;
using PipelineDesignPattern.SimpleImplement.Pipeline;

namespace PipelineDesignPattern.SimpleImplement.Framework
{
    internal class ExceptionHandlingStep : IPipelineStep
    {
        public void Exceute(IPoplineContext context, Func<IPoplineContext, bool> func)
        {
            try
            {
                func(context);
            }
            catch (Exception c)
            {
                "exception occurod".Dump(c.Message);
            }
        }
    }
}
