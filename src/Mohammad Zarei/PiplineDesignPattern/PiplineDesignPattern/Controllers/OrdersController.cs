using Dumpify;

namespace PiplineDesignPattern.Controllers;

public sealed class OrdersController
{
    private readonly Context _context;

    public OrdersController(Context context)
    {
        _context = context;
    }

    public void GetAll()
    {
        "Let's return orders list . . .".Dump();
    }
}

