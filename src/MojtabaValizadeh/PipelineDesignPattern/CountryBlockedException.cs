namespace PipelineDesignPattern;

public class CountryBlockedExceptionHandler:Exception
{
    public CountryBlockedExceptionHandler() : base() { }

    public CountryBlockedExceptionHandler(string message) : base(message) { }

    public CountryBlockedExceptionHandler(string message, Exception innerException) : base(message, innerException) { }
}