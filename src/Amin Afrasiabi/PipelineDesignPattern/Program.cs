using Dumpify;

namespace PipelineDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productsController = new ProductsController();
            var framework = new Framework();

            var httpContext1 = new HttpContext { IP = "216.239.38.10" };
            var httpContext2 = new HttpContext { IP = "216.239.38.20" };
            var httpContext3 = new HttpContext { IP = "216.239.38.30" };


            framework.Authentication(httpContext2, (context) =>
                                     framework.ExceptionHandling(context, productsController.GetAllUsers)
                                     );
            framework.Authentication(httpContext3, (context) =>
                                     framework.ExceptionHandling(context, productsController.GetAllUsers)
                                     );
            framework.Authentication(httpContext1, (context) =>
                                     framework.ExceptionHandling(context, productsController.GetAllUsers)
                                     );
        }
    }
}
