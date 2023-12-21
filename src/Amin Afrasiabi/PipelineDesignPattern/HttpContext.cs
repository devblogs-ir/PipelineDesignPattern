namespace PipelineDesignPattern;
public class HttpContext
{
    public CountryIPAddress Country => Enum.TryParse(IP[^2..], out CountryIPAddress country) ? country : 0;
    public required string IP { get; set; }
}
public enum CountryIPAddress
{
    UnKnown = 0,
    Iran = 10,
    China = 20,
    USA = 30,
}