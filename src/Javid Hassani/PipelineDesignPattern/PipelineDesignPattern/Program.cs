// See https://aka.ms/new-console-template for more information
using PipelineDesignPattern;

Console.WriteLine("Hi, Please Enter your Ip");

string Ip = Console.ReadLine()!;
while (true)
{
    if (string.IsNullOrEmpty(Ip))
    {
        Console.WriteLine("Please Enter your Ip");
        Ip = Console.ReadLine()!;
    }
    else
        break;
}

Context httpContext = new() { Ip = Ip };
var pipe = new Pipe();
var userService = new UserService();

pipe.ExceptionHandling(httpContext,
    (context) => pipe.Authurization(httpContext,(context) => pipe.Cors(httpContext, userService.GetUserData)));

Console.ReadKey();

