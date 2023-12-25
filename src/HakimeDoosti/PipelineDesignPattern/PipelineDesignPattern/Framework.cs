using Dumpify;

namespace PipelineDesignPattern
{
    public class Framework
    {
        public delegate void Action(HttpContext context);
        public void ExceptionHandling(HttpContext context, Action<HttpContext> action)
        {
            try
            {
                action(context);
            }
            catch (CustomException ex)
            {
                ex.Message.Dump();
            }

        }
        public void Cors(HttpContext context, Action<HttpContext> action)
        {
            if (context is null) throw new CustomException("context is null ");
            if (context.IP is null) throw new CustomException("IP is null ");
            action(context);
            "end Cors".Dump();
        }
        public void Routing(HttpContext context, Action<HttpContext> action)
        {
            "Routing".Dump();
            if (context is null) throw new CustomException("context is null ");
            if (context.IP is null) throw new CustomException("IP is null ");
            action(context);

        }
        public void Authentication(HttpContext context, Action<HttpContext> action)
        {
            "begin Authentication".Dump();
            if (context is null) throw new CustomException("context is null "); 
            if (context.IP is null) throw new CustomException("IP is null ");
            if (context.IP == "192.15.0.0") throw new CustomException("you are from Iran");

           
            action(context);
            "end Authentication".Dump();


        }
    }
}
