namespace PipeLineDesignPattern;

public class ProductController
{
    private readonly HttpContext _Content;

    public ProductController(HttpContext content)
    {
        _Content = content;
    }

    public void GetAll(HttpContext httpContext)
    {
        Console.WriteLine("Get all Products"):;
    }
}
