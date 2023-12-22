namespace PipelineDesignPattern.Exceptions;

public class ForbiddenAccessException(string message) : Exception(message)
{
}
