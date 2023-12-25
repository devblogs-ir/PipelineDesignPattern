using Dumpify;

public sealed class Framework
{
    public void ExceptionHandling(
        Action<Context> action,
        Context context)
    {
        try
        {
            action(context);
        }
        catch (BlockedIpException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Something went wrong!!!\nHere you " +
                $"can see details: {ex.Message}");
            Console.ResetColor();
        }
    }

    public void Authentication(
        Action<Context> action,
        Context myContext)
    {
        "Starting Authentication for user with IP: ".Dump($"{myContext.UserIp}");

        Console.WriteLine("Authenticating: Checking user credentials . . .");

        if (myContext.UserIp.ToLower().Contains("iran"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Authentication failed for user with ip: {myContext.UserIp}!!!");
            Console.ResetColor();
            throw new BlockedIpException(myContext.UserIp);
        }

        action(myContext);

        "Ending Authentication for".Dump($"{myContext.UserIp}");
    }
}
