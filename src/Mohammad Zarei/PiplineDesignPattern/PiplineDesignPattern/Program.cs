var userFromAmerica = new MyContext { UserIp = "America Ip" };
var userFromIran = new MyContext { UserIp = "Iran Ip" };

var framework = new Framework();
var controller = new ProductsController();

framework.ExceptionHandling((context)
    => framework.Authentication(controller.GetAll, userFromAmerica), userFromAmerica);

framework.ExceptionHandling((context)
    => framework.Authentication(controller.GetAll, userFromIran), userFromIran);
