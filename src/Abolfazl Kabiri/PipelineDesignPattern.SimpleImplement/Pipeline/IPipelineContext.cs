namespace PipelineDesignPattern.SimpleImplement.Pipeline;
public interface IPipelineContext
{
    public string RequestIpAddress { get; set; }
    public string Country { get; set; }
    public string Url { get; set; }
}
