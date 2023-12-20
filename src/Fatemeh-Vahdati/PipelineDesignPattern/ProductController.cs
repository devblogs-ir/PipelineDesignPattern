using Newtonsoft.Json.Linq;

namespace PipelineDesignPattern
{
    public class ProductController
    {
        public void Print(HttpContext httpContext)
        {
            Console.WriteLine("Request Accepted");
        }
    }
}
