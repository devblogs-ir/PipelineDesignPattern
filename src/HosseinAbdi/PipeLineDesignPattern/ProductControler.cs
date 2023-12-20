using Dumpify;

class ProductController
{
    public delegate void Action();
    public void GetAllIP(HttpContext httpContext)
    {
        $"user IP is {httpContext.IP}".Dump("Return All IP");
    }


    
}