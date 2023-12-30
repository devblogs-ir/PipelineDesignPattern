// See https://aka.ms/new-console-template for more information
using PipelineDesignPattern;
using PipelineDesignPattern.Pipes;

Console.WriteLine("Hi, Please Enter your Ip");

string ip = Console.ReadLine()!;
while (true)
{
    if (string.IsNullOrEmpty(ip))
    {
        Console.WriteLine("Please Enter your Ip");
        ip = Console.ReadLine()!;
    }
    else
        break;
}

Context httpContext = new(ip, "User/GetUserById?id=1");
var app = new PipelineBuilder();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<AuthorizationMiddleware>();
app.UseMiddleware<RequestMappingMiddleware>();

app.Build(httpContext);

Console.ReadKey();

