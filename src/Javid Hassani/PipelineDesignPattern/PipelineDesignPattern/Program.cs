// See https://aka.ms/new-console-template for more information
using PipelineDesignPattern;

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

Context httpContext = new(ip);

var userService = new UserService();

Pipe.ExceptionHandling(httpContext,
    (context) => Pipe.Authurization(httpContext,
    (context) => Pipe.Cors(httpContext, userService.GetUserData)));

Console.ReadKey();

