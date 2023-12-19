using Dumpify;
using PipelineDesignPattern.Exceptions;
using System.Text.Json;

namespace PipelineDesignPattern;

public class UserService
{
    private readonly Dictionary<string, User> _users = new()
    {
        {"111.111.111.111", new User("ali", "rezaie") },
        {"222.333.333.333", new User("mohammad", "ahmadi") },
        {"444.444.444.444", new User("reza", "navidi") },

    };
    public void GetUserData(Context context)
    {
        var user = _users[context.Ip];
        if (user == null)
            throw new NotFoundException("user with specified IP not found");

        JsonSerializer.Serialize(user).Dump();
    }
}
