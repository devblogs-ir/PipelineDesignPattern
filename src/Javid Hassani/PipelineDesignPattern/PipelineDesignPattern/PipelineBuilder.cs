using PipelineDesignPattern.Pipes;

namespace PipelineDesignPattern;

public class PipelineBuilder
{
    private List<Type> _types = new();

    public PipelineBuilder UseMiddleware<T>() where T : class
    {
        _types.Add(typeof(T));
        return this;
    }

    public void Build(Context context)
    {
        List<Middleware> pipes = new();
        Action<Context> next = null!;

        for (int i = _types.Count - 1; i >= 0; i--)
        {
            var instance = Activator.CreateInstance(_types[i], new[] { next }) as Middleware;

            next = instance.Handle;
            pipes.Add(instance);
        }
        pipes.Last().Handle(context);
    }
}
