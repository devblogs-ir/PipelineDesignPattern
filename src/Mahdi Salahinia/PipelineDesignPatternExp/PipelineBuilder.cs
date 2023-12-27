namespace PipelineDesignPatternExp;

public class PipelineBuilder
{
    private List<Type> _types = [];

    public PipelineBuilder AddPipe(Type type)
    {
        _types.Add(type);
        return this;
    }

    public PipelineBuilder Build(HttpContext httpContext, Action<HttpContext> action)
    {
        foreach (var type in _types)
        {
            var getType = Type.GetType($"PipelineDesignPatternExp.{type.Name}");

            var method = getType.GetMethod("Handle");

            //var parameters = method.GetParameters();

            var runTimeInstance = Activator.CreateInstance(type, new[] { action });

            method.Invoke(runTimeInstance, new[] { httpContext });
        }

        return this;
    }
}
