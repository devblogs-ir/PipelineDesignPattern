namespace PipLineDesignPattern;

public class IpNotTrueException : ApplicationException
{
    public IpNotTrueException(int ip)
        : base($"this IP : --{ip}-- Not True . ")
    {
    }
}