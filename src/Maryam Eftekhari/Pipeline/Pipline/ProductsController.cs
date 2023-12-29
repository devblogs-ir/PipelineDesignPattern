using Dumpify;
using Pipeline.Context;

namespace Pipeline
{
    public class ProductsController
    {
        public void GetAllProducts(HttpContext context)
        {
            "Get All Products".Dump();
        }
    }
}
