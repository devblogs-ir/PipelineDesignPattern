using Dumpify;

namespace PipelineDesignPattern
{
    public class ProductController(HttpContext httpContext)
    {
        public void GetAll()
        {
            if (httpContext.IP == null) 
                throw new CustomException(" IP Is null ");

            if (httpContext == null) 
                throw new CustomException(" httpContext Is null ");

            $"user id :{httpContext.IP} retrn all user".Dump();
        }
        public void GetUserBuyId( int Id)
        {
            $"GetUserBuyId:{Id}".Dump();
        }

    }
}
