namespace PipelineDesignPattern.SimpleImplement.Pipeline;
public interface IPipelineStep
{
    public Action<IPipelineContext> Action { get; set; }
    void Exceute(IPipelineContext context);
}

public interface IEndPointPipelineStep<T>
{
    public Func<T> Func { get; set; }
    void Exceute(IPipelineContext context);
}
