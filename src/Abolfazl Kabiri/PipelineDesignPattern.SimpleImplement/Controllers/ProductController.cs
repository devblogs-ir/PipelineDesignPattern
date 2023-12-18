using Dumpify;

namespace PipelineDesignPattern.SimpleImplement.Controllers
{
    internal class ProductController
    {
        string GetAllProducts()
        {
            return "return all products".Dump();
        }
    }
}
