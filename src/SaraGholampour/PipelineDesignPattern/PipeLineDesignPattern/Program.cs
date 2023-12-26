using PipeLineDesignPattern;

HttpContext getAllProductsReq = new()
{
    Ip = "123.185.20.177",
    Url = "localhost/Products/GetAll"
};

Framework framework = new();

public abstract class Pipe
{
    // public Pipe(Action<HttpContext> next)
    // {
    //     _next = next;
    // }

    public Action<HttpContent> _next;

    public void Handle(HttpContent httpContent)
    {
    }
}

// public class ExceptionHandling(Action<HttpContext> nextAction):Pipe(nextAction)
