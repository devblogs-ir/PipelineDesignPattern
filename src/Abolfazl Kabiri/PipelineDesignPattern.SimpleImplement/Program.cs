using CommandLine;
using PipelineDesignPattern.SimpleImplement.Controllers;
using PipelineDesignPattern.SimpleImplement.Framework;
using PipelineDesignPattern.SimpleImplement.Patterns;
using PipelineDesignPattern.SimpleImplement.Pipeline;

public class Program
{
    public static void Main(string[] args)
    {
        Parser.Default
            .ParseArguments<HttpRequestPattern>(args)
            .WithParsed(option =>
            {
                // set context in pipeline
                PipelineContext pipelineContext = new() { RequestIpAddress = option.Ip, Country = option.Country, Url = option.Url };

                // init pipes
                var cors = new CorsPipe();
                var exceptionhandling = new ExceptionHandlingPipe();
                var route = new RoutePipe();
                var product = new ProductController();
                var authentication = new AuthenticationPipe();

                // setup action chaining in pipeline
                cors.Next = exceptionhandling.Invoke;
                exceptionhandling.Next = route.Invoke;
                route.Next = authentication.Invoke;
                authentication.Next = new EndPointPipe().Invoke;

                // set pipes and run 
                new Pipeline(pipelineContext)
                              .AddPipe(cors)
                              .AddPipe(exceptionhandling)
                              .AddPipe(route)
                              .AddPipe(authentication)
                              .Run();
            });
        Console.ReadKey();
    }

}
