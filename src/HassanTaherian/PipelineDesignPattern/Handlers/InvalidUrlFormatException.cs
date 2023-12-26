namespace PipelineDesignPattern.Handlers;
public class InvalidUrlFormatException(string url) : ApplicationException(Messages.InvalidUrlFormatException(url))
{
}