namespace PipelineDesignPattern.Pipes;

public abstract class Middleware
{
    public Action<Context> _next;

    public Middleware(Action<Context> next)
    {
        _next = next;
    }
    public abstract void Handle(Context context);
}
