namespace PipelineDesignPattern.Handlers;
public class EndPointNotFoundException(string url) : ApplicationException(Messages.EndPointNotFoundException(url))
{
}