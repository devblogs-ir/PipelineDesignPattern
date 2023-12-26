using CommandLine;

namespace PipelineDesignPattern.SimpleImplement.Patterns;
public class HttpRequestPattern
{
    [Option(shortName: 'c', longName: "country", HelpText = "the name of your country", Required = true)]
    public required string Country { get; set; }

    [Option(shortName: 'i', longName: "ip", HelpText = "your ip request", Required = true)]
    public required string Ip { get; set; }

    [Option(shortName: 'u', longName: "url", HelpText = "your endpoint request url", Required = true)]
    public required string Url { get; set; }

}
