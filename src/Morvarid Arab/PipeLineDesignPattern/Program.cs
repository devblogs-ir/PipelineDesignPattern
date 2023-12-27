using PipeLineDesignPattern;

 class Program
{
    private static void Main(string[] args)
    {
        //var framework = new Framework();
        //var countryController = new CountriesController();
        //var userController = new UserController();

        HttpContext requestFromIran = new()
        {
            IP = "10.10.1.1",
            URL = "localhost:4545/Products/GetUserById/0"
        };

        HttpContext requestFromUSA = new()
        {
            IP = "10.10.1.2",
            URL = "localhost:4545/Products/GetUserById/1"
        };

        var pipeline = new PipelineBuilder()
                                .AddPipe(typeof(ExceptionHandlingPipe))
                                .AddPipe(typeof(AuthenticationPipe))
                                .AddPipe(typeof(EndPointPipe));

        //pipeline.Handle(requestUserFromIran);
        //pipeline.Handle(requestUserFromUSA);

        pipeline.Run(requestFromIran);
    }
}