namespace PipelineDesignPattern.SimpleImplement.CustomExceptions;
public class UnknownIpAddressException : Exception
{
    public UnknownIpAddressException(string ipAddress) : base(ipAddress)
    {
    }
}
