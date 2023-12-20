using PipeLineDesignPattern;

var framework = new FrameWork();

var httpContext1 = new HttpContext() { UserIp = "IRAN" };

var httpContext2 = new HttpContext() { UserIp = "CANADA" };

framework.ExceptionHandling(httpContext1, framework.Authentication);

framework.ExceptionHandling(httpContext2, framework.Authentication);





