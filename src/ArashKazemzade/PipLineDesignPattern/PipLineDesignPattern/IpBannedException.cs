namespace PipLineDesignPattern
{
    public class IpBannedException:ApplicationException
    {
        public IpBannedException(int ip)
            :base($"this IP : --{ip}-- could not available to send REQUEST")
        {
        }
    }
}
