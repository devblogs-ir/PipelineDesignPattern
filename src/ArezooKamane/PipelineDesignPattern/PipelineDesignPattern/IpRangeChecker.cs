using System.Net;

namespace PipelineDesignPattern;

public class IpRangeChecker
{
    public static bool IpRangeCheck(string ipAddressToCheck)
    {

        List<IPRange> iranIPRanges = LoadIPRangesFromCSV(Path.Combine(Environment.CurrentDirectory , "ir.csv"));


        return IsIPInRanges(ipAddressToCheck, iranIPRanges) ? true : false;


    }

    static List<IPRange> LoadIPRangesFromCSV(string filePath)
    {
        var ipRanges = new List<IPRange>();

        foreach (var line in File.ReadLines(filePath))
        {
            var columns = line.Split(',');
            if (columns.Length >= 2)
            {
                IPAddress fromIP, toIP;

                if (IPAddress.TryParse(columns[0], out fromIP) && IPAddress.TryParse(columns[1], out toIP))
                {
                    ipRanges.Add(new IPRange(fromIP, toIP));
                }
            }
        }
        return ipRanges;
    }

    static bool IsIPInRanges(string ipAddress, List<IPRange> ranges)
    {
        if (IPAddress.TryParse(ipAddress, out IPAddress ip))
        {
            return ranges.Any(range => range.Contains(ip));
        }

        return false;
    }

}

