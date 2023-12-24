namespace PipelineDesignPattern;
public class OrdersController
{
    private readonly HttpContext _content;
    
    public OrdersController(HttpContext content)
    {
        _content = content;
    }

    public void GetAll()
    {
        Console.WriteLine("all orders");
    }
}