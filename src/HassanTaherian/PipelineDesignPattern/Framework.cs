namespace PipelineDesignPattern;

using Dumpify;

internal class Framework
{
    private readonly IDictionary<int, string> blackList = new Dictionary<int, string>()
    {
        {83, "Iran"},
        {31, "Russia"},
        {43, "Sudan"},
        {13, "North Korea"},
    };
    public void Auth(HttpContext context, Action<HttpContext> action)
    {
        "Start Auth".Dump();

        if (blackList.ContainsKey(context.IP))
        {
            throw new Exception($"Your from {blackList[context.IP]}:(");
        }

        action(context);
    }
    public void ExceptionHandling(HttpContext context, Action<HttpContext> action)
    {
        try
        {
            action(context);
        }
        catch (Exception ex)
        {
            ex.Dump();
        }
        finally
        {
            "End Exception Handling".Dump();
        }
    }

    public void Routing(HttpContext context, Action<HttpContext> action)
    {
        "Start Routing".Dump();
        action(context);
    }

}
