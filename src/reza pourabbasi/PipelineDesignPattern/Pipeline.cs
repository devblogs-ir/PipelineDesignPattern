namespace PipelineDesignPattern;
public class Pipeline
{
    private readonly List<IPipe> _pipes = new();
    public Pipeline Add(IPipe pipe)
    {
        if (pipe is not IPipe) throw new Exception();

        _pipes.Add(pipe);
        return this;
    }
    public void Run(HttpContext httpContext)
    {
        for (int i = 0; i < _pipes.Count; i++)
        {
            _pipes[i]._next = i + 1 == _pipes.Count ? null : _pipes[i + 1].HandleAsync;
        }
        _pipes[0].HandleAsync(httpContext);
    }
}