using PipelineDesignPattern.Handlers;

namespace PipelineDesignPattern;
public class PipelineBuilder
{
    private BaseHandler? entryPoint { get; set; }
    private BaseHandler? lastHandler { get; set; }

    public PipelineBuilder AddHandler(BaseHandler baseHandler)
    {
        if (!IsThereHandlerInPipeline())
        {
            entryPoint = baseHandler;
            lastHandler = baseHandler;
        }
        else
        {
            lastHandler.Next = baseHandler.Handle;
            lastHandler = baseHandler;
        }
        return this;
    }

    private bool IsThereHandlerInPipeline()
    {
        return lastHandler is not null;
    }


    public void Run(HttpContext httpContext)
    {
        entryPoint?.Handle(httpContext);
    }

}
