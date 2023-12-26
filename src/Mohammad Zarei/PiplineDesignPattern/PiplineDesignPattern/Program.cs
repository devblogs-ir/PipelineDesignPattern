var userFromAmerica = new Context { UserIp = "America Ip" };
var userFromIran = new Context { UserIp = "Iran Ip" };

var framework = new Framework();
var controller = new ProductController();

framework.ExceptionHandling((context)
    => framework.Authentication(controller.GetAll, userFromAmerica), userFromAmerica);

framework.ExceptionHandling((context)
    => framework.Authentication(controller.GetAll, userFromIran), userFromIran);
