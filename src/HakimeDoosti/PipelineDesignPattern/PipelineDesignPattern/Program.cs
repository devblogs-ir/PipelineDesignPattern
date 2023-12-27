// See https://aka.ms/new-console-template for more information


using PipelineDesignPattern;

HttpContext request1 = new()
{
    IP = "102.15.0.0",
    Url = "https://localhost:44387/Product/GetUserBuyId/3"
};

HttpContext request2 = new()
{
    IP = "192.15.0.0",
    Url = "https://localhost:44387/Product/GetUserBuyId/3"
};

Framework framework = new();

framework.ExceptionHandling(request1,
    (context) => framework.Authentication(context,
    (context) => framework.EndpointHandling(context, null!)));



var endpointPip = new EndpointPip(null!);
var authenticationPip = new AuthenticationPip(endpointPip.Handel);
var exeptionHandling = new ExceptionHandlingPip(authenticationPip.Handel);

exeptionHandling.Handel(request1);

exeptionHandling.Handel(request2);


