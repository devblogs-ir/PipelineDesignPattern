using Dumpify;

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
        $"return all Products Ip= {_context.IP} Url={_context.Url}".Dump();
    }
    public void GetByID(int Id)
    {
        var item = new List<string> { "Monitor" , "RAM" , "CPU" , "HDD"};
        $"Product id = {Id} & Product Name = {item[Id]} .".Dump();
    }
}
