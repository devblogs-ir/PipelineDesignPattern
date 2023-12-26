namespace PipelineDesignPattern;
public class ProductsController
{
    private readonly HttpContext _context;
    public ProductsController(HttpContext context)
    {
            _context = context;
    }
    public void GetAll()
    {
        Console.WriteLine("all products");
    }
}