namespace PipelineDesignPattern.Exceptions;
public class IPNotProvideException : Exception
{
    public IPNotProvideException() { }
    public IPNotProvideException(string message) : base(message) { }
}