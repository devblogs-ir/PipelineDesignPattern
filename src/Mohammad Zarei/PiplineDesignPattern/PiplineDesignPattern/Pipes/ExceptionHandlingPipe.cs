using Dumpify;
using PiplineDesignPattern.Exceptions;

namespace PiplineDesignPattern.Pipes;

public class ExceptionHandlingPipe(Action<Context> next) : Pipe(next)
{
    public override void Handle(Context context)
    {
        try
        {
            "starting Exception handling . . .".Dump();
            if (context is not null)
                _next(context);
            "end Exception handling . . .".Dump();
        }
        catch (BlockedIpException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Something went wrong!!!\nHere you " +
                $"can see details: {ex.Message}");
            Console.ResetColor();
        }
    }
}
