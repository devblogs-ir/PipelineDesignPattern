using System.Net.Http;

namespace PipelineDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductController controller = new ProductController();
            HttpContext context = new HttpContext() { IP = "Iran" };
            HttpContext context1 = new HttpContext() { IP = "USA" };


            Framework framework = new Framework();

            framework.Authentication(context1,
                (context1) => framework.ExceptionHandling(context1, ((context1) => controller.GetAllProducts(context1))));

            framework.Authentication(context,
                (context) => framework.ExceptionHandling(context, ((context) => controller.GetAllProducts(context))));



        }
    }
}
