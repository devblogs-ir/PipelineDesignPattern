using Dumpify;

namespace PipelineDesignPattern.SimpleImplement.Controllers
{
    public class ProductController
    {
        public string GetAllProducts()
        {
            return "return all products".Dump();
        }
    }
}
