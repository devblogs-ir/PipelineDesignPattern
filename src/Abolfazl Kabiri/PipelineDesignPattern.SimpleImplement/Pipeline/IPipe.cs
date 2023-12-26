namespace PipelineDesignPattern.SimpleImplement.Pipeline;
public interface IPipe
{
    public Action<IPipelineContext> Next { get; set; }
    void Invoke(IPipelineContext context);
}

