namespace PipelineDesignPattern
{
    internal class Framework
    {
        public delegate void Action();
        internal void Authentication(HttpContext httpContext, Action<HttpContext> function)
        {
            if (httpContext.Ip is "37.255.130.023")
            {
                throw new Exception(" you are from iran");
            }
            function(httpContext);
        }

        internal void ExceptionHandeling(HttpContext httpContext, Action<HttpContext> function)
        {
            Console.WriteLine("starting Exception Handeling");
            try
            {
                function(httpContext);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
