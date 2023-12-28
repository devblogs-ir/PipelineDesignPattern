namespace PipeLineDesignPattern;

public class ProductsController
{
    private readonly HttpContext _Content;

    public ProductsController(HttpContext content)
    {
        _Content = content;
    }

    public void GetAll(HttpContext httpContext)
    {
        Console.WriteLine("Get all Products");
    }
}
