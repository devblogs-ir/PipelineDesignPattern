namespace PipelineDesignPattern.Exceptions;

public class NotFoundException(string message) : Exception(message)
{
}
