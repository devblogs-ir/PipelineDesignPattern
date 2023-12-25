using Dumpify;

namespace PipelineCLITool;
public class ProductsController
{
    private readonly HttpContext _httpContext;

    public ProductsController(HttpContext httpContext)
    {
        _httpContext = httpContext;
    }
    // Products/GetAllProducts
    public void GetAllProducts()
    {
        "List of all products.".Dump();
    }
    List<User> users = new List<User>()
    {
        new User() { Id = 1, Name = "User1" },
        new User() { Id = 2, Name = "User2" },
        new User() { Id = 3, Name = "User3" },
        new User() { Id = 4, Name = "User4" },
        new User() { Id = 3, Name = "User5" },
    };
    public string GetUserById(int id)
    {
        if (!users.Any(p => p.Id == id))
            return "No user was found!".Dump();
        return users.SingleOrDefault(p => p.Id == id)
            .Name.Dump();
    }
}
