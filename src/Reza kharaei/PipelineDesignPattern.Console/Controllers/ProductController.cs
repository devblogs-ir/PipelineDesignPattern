using PipelineDesignPattern.Framework;

namespace PipelineDesignPattern.Controllers;

public class ProductController
{
    public void GetAll(HttpContext httpContext)
    {
         Console.WriteLine("Return Products List...");
    }

    public void GetById()
    {

    }
}