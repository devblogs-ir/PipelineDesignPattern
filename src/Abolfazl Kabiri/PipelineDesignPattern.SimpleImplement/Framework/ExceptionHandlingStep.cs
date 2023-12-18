using Dumpify;
using PipelineDesignPattern.SimpleImplement.Pipeline;

namespace PipelineDesignPattern.SimpleImplement.Framework
{
    public class ExceptionHandlingStep : IPipelineStep
    {
        public Action<IPipelineContext> Action { get; set; }
        public void Exceute(IPipelineContext context)
        {
            try
            {
                "starting exception handling".Dump();
                Action(context);
            }
            catch (Exception c)
            {
                "exception occurod".Dump(c.Message);
            }
        }
    }
}
