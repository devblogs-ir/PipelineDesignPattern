namespace PipelineDesignPattern.Handlers;
public class EndPointNotFoundException(string url) : Exception(Messages.EndPointNotFoundException(url))
{
}