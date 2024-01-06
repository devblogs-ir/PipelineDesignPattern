//ExceptionHandling
//Authentication -> if iranian ip=> throw exception (message : you are from iran)

using PipeLineApp;

FilteringController controller = new();
var iranAccess = new HttpContext {Ip = "192.168.1.1"};
var internationAccess = new HttpContext {Ip = "192.168.1.2"};
Framework.ExceptionHandling(iranAccess, context => Framework.Authentication(context, controller.GetIp));
Framework.ExceptionHandling(internationAccess, context => Framework.Authentication(context, controller.GetIp));