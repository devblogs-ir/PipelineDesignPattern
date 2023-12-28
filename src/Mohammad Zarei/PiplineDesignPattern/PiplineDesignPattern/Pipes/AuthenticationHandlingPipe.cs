using PiplineDesignPattern.Exceptions;
using Dumpify;

namespace PiplineDesignPattern.Pipes;

public class AuthenticationHandlingPipe(Action<Context> next) : Pipe(next)
{
    public override void Handle(Context context)
    {
        "Starting Authentication for user with IP: ".Dump($"{context.UserIp}");

        Console.WriteLine("Authenticating: Checking user credentials . . .");

        if (context.UserIp.ToLower().Contains("iran"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Authentication failed for user with ip: {context.UserIp}!!!");
            Console.ResetColor();
            throw new BlockedIpException(context.UserIp);
        }

        if (context is not null)
            _next(context);

        "Ending Authentication for".Dump($"{context.UserIp}");
    }
}
