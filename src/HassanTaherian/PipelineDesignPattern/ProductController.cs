namespace PipelineDesignPattern;

using Dumpify;

public class ProductController
{
    public void GetUsers(HttpContext httpContext)
    {
        "All Users".Dump();
    }

    public void GetUserByID(HttpContent httpContent)
    {
        "Single User".Dump();
    }
}
