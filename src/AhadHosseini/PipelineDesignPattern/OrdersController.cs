
using Dumpify;

namespace PipelineDesignPattern;

public class OrdersController
{
    private readonly HttpContext _context;

    public OrdersController(HttpContext context)
    {
        _context = context;
    }

    public void GetAll()
    {
        $"return all Orders {_context.IP}".Dump();
    }
    public void GetByID(int Id)
    {
        var item = new List<string> { "---", "Monitor", "RAM", "CPU", "HDD" };
        $"Order id = {Id} & Product Name = {item[Id]} .".Dump();
    }
}
