using Dumpify;

namespace PipelineDesignPattern.Handlers;
public class ExceptionHandler : BaseHandler
{
    public override void Handle(HttpContext httpContext)
    {
        try
        {
            next?.Invoke(httpContext);
        }
        catch (Exception ex) when (ex is ApplicationException)
        {
            ex.Message.Dump("!!!Error!!!");
        }
        finally
        {
            "End Exception Handling".Dump();
        }
    }
}
