using System.Net;

namespace PipelineDesignPattern;
public class IPRange
{
    public IPAddress FromIP { get; }
    public IPAddress ToIP { get; }

    public IPRange(IPAddress fromIP, IPAddress toIP)
    {
        FromIP = fromIP;
        ToIP = toIP;
    }

    public bool Contains(IPAddress ipAddress)
    {
        byte[] ipBytes = ipAddress.GetAddressBytes();
        byte[] fromBytes = FromIP.GetAddressBytes();
        byte[] toBytes = ToIP.GetAddressBytes();

        for (int i = 0; i < ipBytes.Length; i++)
        {
            if (ipBytes[i] < fromBytes[i] || ipBytes[i] > toBytes[i])
            {
                return false;
            }
        }

        return true;
    }

}

