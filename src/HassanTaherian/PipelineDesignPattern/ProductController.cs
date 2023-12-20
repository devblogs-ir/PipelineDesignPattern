namespace PipelineDesignPattern;

using Dumpify;

internal class ProductController
{
    public static void GetUsers()
    {
        "All Users".Dump();
    }

    public static void GetUserByID()
    {
        $"Single User".Dump();
    }
}
