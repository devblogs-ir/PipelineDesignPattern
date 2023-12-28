using CommandLine;

namespace PipelineDesignPattern
{
    internal class Program
    {
        private static string _ip;
        private static string _url;

    static void Main(string[] args)
        {
        //iran IP = "178.252.190.1
        //IP = "8.8.8.8",
        //Url = "localhost:8080/Products/GetAllProducts"


        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(RunOptions)
            .WithNotParsed(HandleParseError);



        var pipeline = new PipelineBuilder()
                .UsePipe(typeof(ExceptionHandlingPipe))
                .UsePipe(typeof(AuthenticationPipe))
                .UsePipe(typeof(EndPointPipe))
                .Build();


            pipeline.Invoke(new HttpContext(){IP = _ip, Url = _url});

    }

        static void RunOptions(Options opts)
        {
            _ip = opts.IP;
            _url = opts.Url;
        }

        static void HandleParseError(IEnumerable<Error> errors)
        {
            Console.WriteLine("Failed to parse command line options."); 
        }

}
class Options
{
    [Option('i', "ip", Required = true, HelpText ="IP")]
    public string IP { get; set; }


    [Option('u', "url", Required = true, HelpText = "URL")]
    public string Url { get; set; }

}
}
