

Framework framework=new();
ProductController productcontroller=new();

var httpContextIR=new HttpContext {IP="10.10.1.1"}; //IR IP 
var httpContextUS=new HttpContext {IP="11.10.1.1"}; //US IP

framework.ExceptionHandeling(httpContextIR, (context) => framework.Authentication(httpContextIR,productcontroller.GetAllIP));
framework.ExceptionHandeling(httpContextUS, (context) => framework.Authentication(httpContextUS,productcontroller.GetAllIP));

 public class HttpContext
 {
    public string? IP{ get; set; }
 }                                

