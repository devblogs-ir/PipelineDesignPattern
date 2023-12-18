namespace PipelineDesignPattern.SimpleImplement.Pipeline
{
    public class PipelineContext : IPipelineContext
    {
        public required string RequestIpAddress { get; set; }
    }
}
