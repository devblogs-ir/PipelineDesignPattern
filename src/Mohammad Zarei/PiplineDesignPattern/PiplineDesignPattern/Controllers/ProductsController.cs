using Dumpify;

public sealed class ProductsController
{
    public void GetAll(MyContext myContext)
    {
        "returing products list . . . for".Dump($"{myContext.UserIp}");
    }
}
