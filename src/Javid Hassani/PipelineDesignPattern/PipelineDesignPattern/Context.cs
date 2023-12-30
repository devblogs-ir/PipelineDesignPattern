namespace PipelineDesignPattern;

public class Context
{
    public Context(string ip, string route)
    {
        Ip = ip;
        Route = route;
    }

    public string Ip { get; init; }
    public string Route { get; init; }
}