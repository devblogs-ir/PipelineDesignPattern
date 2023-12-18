using Dumpify;

namespace PipelineDesignPattern
{
    public class ProductController
    {
        public void GetAllProducts(HttpContext httpContext) {
            "List of all products.".Dump();
        }
    }
}
