using Dumpify;

namespace PipelineDesignPattern
{
    public class ProductController
    {
        public void GetAllUser(HttpContext httpContext)
        {
            if (httpContext.IP == null) throw new Exception(" IP Is null ");
            $"user id :{httpContext.IP} retrn all user".Dump();
        }
        public void GetUserBuyId()
        {
            "GetUserBuyId".Dump();
        }

    }
}
