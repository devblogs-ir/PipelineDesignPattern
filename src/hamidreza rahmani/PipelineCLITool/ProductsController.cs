namespace PipelineDesignPattern;
public class ProductsController
{
    private readonly HttpContext _content;
    
    public ProductsController(HttpContext content)
    {
        _content = content;
    }

    public void GetAll()
    {
        Console.WriteLine("all products");
    }



    public void GetUserById(int Id)
    {
        var items = new List<string> { 
            "Mohammad Karimi",
            "Nabi Karampoor",
            "Abolfazl Kabiri",
            "Ahad Hosseini"
        };
         
        Console.WriteLine($"User {Id} : {items[Id]}");
    }
}

 