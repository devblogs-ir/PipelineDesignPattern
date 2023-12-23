using Dumpify;

namespace PipelineDesignPattern;
public class ProductsController
{
    public void GetAllUsers(HttpContext httpContext)
    {
        $"Your IP is {httpContext.IP} from {httpContext.Country}".Dump(label: "Return All Users");
    }
}
