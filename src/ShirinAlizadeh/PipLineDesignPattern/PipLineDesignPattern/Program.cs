using PipLineDesignPattern;
Framework framework = new();
IpController ipController = new();
HttpContext context = new HttpContext() { IPIdUser= "170" };
var test = ipController.GetIpByIdUser(context);
IPContery ipcountry = new IPContery
{
    IPIraq = test
};

framework.Routing(context,
    (context)=> framework.CORS(context, 
    (context) => framework.ExceptionHandling(context,
    (context) => framework.Autentication(context, ipcountry,  ipController.GetIpByIdUser))));





