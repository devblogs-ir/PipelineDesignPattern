

namespace PipelineDesignPattern.Frameworks;
public class EndPoint : PipeBase
{
    public override async Task HandleAsync(HttpContext httpContext)
    {
        ProductsController productsController = new();
        productsController.GetAll(httpContext);
    }
}
