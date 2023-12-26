namespace PipelineDesignPattern;
public class IPNotProvideException : Exception
{
    public IPNotProvideException() { }
    public IPNotProvideException(string message) : base(message) { }
}