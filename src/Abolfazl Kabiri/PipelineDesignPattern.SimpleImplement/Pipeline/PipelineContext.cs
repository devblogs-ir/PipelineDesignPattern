namespace PipelineDesignPattern.SimpleImplement.Pipeline;
public class PipelineContext : IPipelineContext
{
    public required string RequestIpAddress { get; set; }
    public required string Country { get; set; }
    public required string Url { get; set; }
}
