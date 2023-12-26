using PipelineDesignPattern.SimpleImplement.CustomExceptions;

namespace PipelineDesignPattern.SimpleImplement.Pipeline;
public class Pipeline
{
    readonly IPipelineContext _context;
    readonly List<IPipe> pipes;

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

    public void Run()
    {
        if (!pipes.Any()) throw new NotImplementedPipelineException();
        pipes[0].Invoke(_context);
    }
}
