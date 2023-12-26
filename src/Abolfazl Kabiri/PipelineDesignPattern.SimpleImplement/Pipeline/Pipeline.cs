namespace PipelineDesignPattern.SimpleImplement.Pipeline;
public class Pipeline
{
    readonly IPipelineContext _context;

    List<IPipe> pipes;

    public Pipeline(IPipelineContext context)
    {
        _context = context;
        pipes = new List<IPipe>();
    }
    public Pipeline AddPipe(IPipe pipe)
    {
        pipes.Add(pipe);
        return this;
    }

    public void Run() => pipes[0].Invoke(_context);
}
