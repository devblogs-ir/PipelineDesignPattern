using Dumpify;

namespace PiplineDesignPattern.Controllers;

public sealed class UsersController
{
    private readonly Context _context;

    public UsersController(Context context)
    {
        _context = context;
    }

    public void GetAll()
    {
        "returing users list . . .".Dump();
    }

    public void Get(int id)
    {
        var users = new List<string>()
        {
            "Ali Alavi",
            "Shirin Tehrani",
            "Reza Razavi"
        };

        "Starting returning user".Dump();

        Console.WriteLine($"User with {id} is: {users[id]}");

        "End of returning user".Dump();
    }
}
