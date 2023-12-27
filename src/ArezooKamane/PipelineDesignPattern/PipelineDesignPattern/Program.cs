namespace PipelineDesignPattern;
    internal class Program
    {
        static void Main(string[] args)
        {
            //HttpContext context = new HttpContext() { IP = "178.252.190.1" };
            HttpContext context1 = new HttpContext()
            {
                IP = "8.8.8.8",
                Url = "localhost:8080/Products/GetAllProducts"

            };


            var pipeline = new PipelineBuilder()
                .UsePipe(typeof(ExceptionHandlingPipe))
                .UsePipe(typeof(AuthenticationPipe))
                .UsePipe(typeof(EndPointPipe))
                .Build();


            pipeline.Invoke(context1);




    }
}

