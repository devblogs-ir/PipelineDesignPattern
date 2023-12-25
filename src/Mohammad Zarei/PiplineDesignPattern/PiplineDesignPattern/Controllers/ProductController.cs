using Dumpify;

public sealed class ProductController
{
    public void GetAll(Context myContext)
    {
        "returing products list . . . for".Dump($"{myContext.UserIp}");
    }
}
