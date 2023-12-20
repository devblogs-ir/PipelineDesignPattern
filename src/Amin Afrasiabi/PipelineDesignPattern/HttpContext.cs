namespace PipelineDesignPattern;
public class HttpContext
{
    public CountryIPPAddress Country => Enum.TryParse(IP[^2..], out CountryIPPAddress country) ? country : 0;
    public required string IP { get; set; }
}
public enum CountryIPPAddress
{
    UnKnown = 0,
    Iran = 10,
    China = 20,
    USA = 30,
}