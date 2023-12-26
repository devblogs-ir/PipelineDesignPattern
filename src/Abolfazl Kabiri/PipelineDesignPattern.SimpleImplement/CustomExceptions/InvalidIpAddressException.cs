namespace PipelineDesignPattern.SimpleImplement.CustomExceptions;
public class InvalidIpAddressException : Exception
{
    public InvalidIpAddressException(string ipAddress) : base(ipAddress)
    {
    }
}
