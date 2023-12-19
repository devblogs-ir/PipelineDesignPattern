using Dumpify;

namespace PipLineDesignPattern
{
    public class FrameWork
    {
        public void Authentication(HttpContext context, Action<HttpContext> action)
        {
            try
            {
                if (context.IP % 10000 > 999) //Its fun
                    throw new IpNotTrueException(context.IP);


                if (context.IP % 1000 / 100 == 1 || context.IP % 1000 / 100 == 2)
                    throw new IpBannedException(context.IP);
                

                $"request MethodName : {nameof(Authentication)} --> IP Address : {(int)context.IP} ".Dump();
                action(context);
            }
            catch (Exception e)
            {
                e.Message.Dump();
            }
        }

        public void ExceptionHandling(HttpContext context, Action<HttpContext> action)
        {
            $"request  MethodName : {nameof(ExceptionHandling)} --> IP Location : {context.IP.ToString()}".Dump();
            action(context);
            $"response MethodName : {nameof(ExceptionHandling)} <-- IP Location : {context.IP.ToString()}".Dump();
        }
        public void SuccessResponse(HttpContext context, Action<HttpContext> action)
        {
            try
            {
                action(context);
                $"response MethodName : {nameof(SuccessResponse)} <-- IP Location : {context.IP.ToString()}".Dump();
            }
            catch (IpBannedException e)
            {
                e.Message.Dump();
            }
            
        }

    }
}
