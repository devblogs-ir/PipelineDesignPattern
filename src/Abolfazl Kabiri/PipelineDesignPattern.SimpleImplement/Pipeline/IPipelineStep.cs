namespace PipelineDesignPattern.SimpleImplement.Pipeline
{
    internal interface IPipelineStep
    {
        void Exceute(IPipelineContext context, Func<IPipelineContext, bool> func);
    }
}
