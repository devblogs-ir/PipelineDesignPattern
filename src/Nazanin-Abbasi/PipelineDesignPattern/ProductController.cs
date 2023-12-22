using Dumpify;

namespace PipelineDesignPattern
{
    public class ProductController
    {
        public void GetAllProduct(HttpContext httpContext)
        {
            $"IP address {httpContext.IP} is eligible.".Dump();
        }
    }
}