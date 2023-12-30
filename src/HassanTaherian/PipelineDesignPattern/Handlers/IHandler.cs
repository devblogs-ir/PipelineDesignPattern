namespace PipelineDesignPattern;
public interface IHandler
{
    Action<HttpContext> Next { set; }

    void Handle(HttpContext context);
}
