namespace PipelineDesignPattern.SimpleImplement.CustomExceptions;
public class InaccessibilityException : Exception
{
    public InaccessibilityException(string country) : base(country)
    {
    }
}
