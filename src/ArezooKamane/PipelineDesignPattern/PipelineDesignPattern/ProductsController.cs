using Dumpify;

namespace PipelineDesignPattern;
    public class ProductsController
    {

        private readonly HttpContext _httpContext;

        public ProductsController(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }
        public void GetAllProducts()
        {
            "all products".Dump();
        }
    }

