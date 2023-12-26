namespace PipelineDesignPattern;
public class PipelineBuilder
{
    private IHandler? entryPoint { get; set; }
    private IHandler? lastHandler { get; set; }

    public PipelineBuilder AddHandler(IHandler baseHandler)
    {
        if (IsThereHandlerInPipeline())
        {
            lastHandler.Next = baseHandler.Handle;
        }
        else
        {
            entryPoint = baseHandler;
        }

        lastHandler = baseHandler;

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
