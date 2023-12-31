using Dumpify;

namespace PipLineDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FrameWork frameWork = new();
            ProductController productController = new();
            "IP must be three digits".Dump();
            "Example : 123 or 980 or 360".Dump();
            var request=Console.ReadLine();
            HttpContext context = new(){IP = Convert.ToInt32(request) };
            frameWork.Authentication(context, (context) => 
                frameWork.ExceptionHandling(context, (context) =>
                    frameWork.SuccessResponse(context, productController.GetAll)));
            

        }
    }
}
