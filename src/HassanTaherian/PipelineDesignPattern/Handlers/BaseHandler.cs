namespace PipelineDesignPattern;
public abstract class BaseHandler : IHandler
{
    protected Action<HttpContext>? next;

    public Action<HttpContext> Next { set => next = value; }

    public abstract void Handle(HttpContext context);
}
