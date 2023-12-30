using Dumpify;
namespace PipelineDesignPattern;

public class ProductController
{
    private readonly HttpContext _httpContext;

    public ProductController(HttpContext httpContext)
    {
        _httpContext = httpContext;
    }

    public void GetAllProduct(int userId)
    {
        $"All Products".Dump();
    }
}