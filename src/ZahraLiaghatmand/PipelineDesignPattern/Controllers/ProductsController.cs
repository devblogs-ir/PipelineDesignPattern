namespace PipelineDesignPattern.Controllers;
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
    public void GetUserById(int Id)
    {
        var items = new List<string>
        {
            "Mohammad",
            "Nabi",
            "Zahra",
            "Arman"
        };
        Console.WriteLine(items[Id]);
    }
}