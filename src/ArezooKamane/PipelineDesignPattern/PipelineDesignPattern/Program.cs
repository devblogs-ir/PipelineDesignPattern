namespace PipelineDesignPattern;
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductController controller = new ProductController();
            HttpContext context = new HttpContext() { IP = "178.252.190.1" };
            HttpContext context1 = new HttpContext() { IP = "8.8.8.8" };


        Framework framework = new Framework();

            framework.Authentication(context1,
                (context1) => framework.ExceptionHandling(context1, ((context1) => controller.GetAllProducts(context1))));

            framework.Authentication(context,
                (context) => framework.ExceptionHandling(context, ((context) => controller.GetAllProducts(context))));



        }
    }

