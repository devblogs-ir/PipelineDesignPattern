using Dumpify;
using PipelineCLITool;

Framework framework = new();

//string? ipArg = null;
//string? urlArg = null;

//for (int i = 0; i < args.Length; i++)
//{
//    if (args[i] == "--ip" && i + 1 < args.Length)
//    {
//        ipArg = args[++i];
//    }
//    else if (args[i] == "--url" && i + 1 < args.Length)
//    {
//        urlArg = args[++i];
//    }
//}

//if (ipArg == null || urlArg == null)
//{
//    "You must specify both --ip and --url.".Dump();
//    return;
//}

//HttpContext request = new()
//{
//    IP = ipArg,
//    Url = urlArg
//};

HttpContext request = new() { 
    IP = "127.0.0.1", 
    Url = "localhost:7777/Products/GetUserById/3"
    };

framework.AuthenticationHandling(request,
    (context) => framework.ExceptionHandling((context),
    (context) => framework.EndpointHandling(context, null!)));