using PipelineCLITool;

static HttpContext getParameters(string[] arguments)
{
    string? ipArg = null;
    string? urlArg = null;

    for (int i = 0; i < arguments.Length; i++)
    {
        if (arguments[i] == "--ip" && i + 1 < arguments.Length)
        {
            ipArg = arguments[++i];
        }
        else if (arguments[i] == "--url" && i + 1 < arguments.Length)
        {
            urlArg = arguments[++i];
        }
    }

    if (ipArg == null || urlArg == null)
    {
        "You must specify both --ip and --url.".Dump();
        return null;
    }

    HttpContext request = new()
    {
        IP = ipArg,
        Url = urlArg
    };
    return request;
}

HttpContext request = getParameters(args);

if(request is not null) {
    var pipeline = new PipelineBuilder()
    .AddPipe(typeof(ExceptionHandlingPipe))
    .AddPipe(typeof(AuthenticationPipe))
    .AddPipe(typeof(EndPointPipe))
    .Build();

    pipeline(request);
}
