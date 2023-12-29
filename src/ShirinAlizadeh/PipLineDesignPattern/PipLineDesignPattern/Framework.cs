using ConsoleDump;

namespace PipLineDesignPattern
{
    public class Framework
    {
        public delegate void Action(HttpContext ip);
        public string Autentication(HttpContext context, IPContery iPContery, Func<HttpContext, string> func)
        {
            if( Country.iPIran + ".120.0.0" == context.IPIdUser+".120.0.0")
            {
                throw new Exception();
            }
            else
            {
                "Start Autentication".Dump();
                func(context);
                return iPContery.IPUsa.Dump();
            }

        }
        public void ExceptionHandling(HttpContext context, Action<HttpContext> func)
        {
            try
            {
              
                func(context);
            }
            catch (Exception e)
            {
                "catched".Dump();
                throw;
            }



        }
        public void CORS(HttpContext context, Action<HttpContext> func)
        {
            "Start CORS".Dump();
       
            func(context);

     
        }
        public void Routing(HttpContext context, Action<HttpContext> func)
        {
            "Start Routing".Dump();
            func(context);
        }

       
    }
}
