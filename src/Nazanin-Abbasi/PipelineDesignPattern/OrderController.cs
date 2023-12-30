using Dumpify;
namespace PipelineDesignPattern;

public class OrderController
{
    private readonly HttpContext _httpContext;

    public OrderController(HttpContext httpContext)
    {
        _httpContext = httpContext;
    }

    public void GetAllOrder()
    {
        $"All Products".Dump();
    }
}