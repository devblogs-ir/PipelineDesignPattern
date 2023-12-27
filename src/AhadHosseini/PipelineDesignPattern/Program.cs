using Dumpify;
using PipelineDesignPattern;
using System;
using System.Reflection;


HttpContext request1 = new HttpContext() { IP = "125.158.220.85", Url = "http://localhost:443/Products/GetByID/3" };
HttpContext request2 = new HttpContext() { IP = "188.158.220.85", Url = "http://localhost:443/Products/GetByID/3" };

var endpointPipe = new EndPointPipe(null);
var authenticationPipe = new AuthenticationPipe(endpointPipe.Handle);
var exceptionHandlingPipe = new ExceptionHandlingPipe(authenticationPipe.Handle);

//exep.Handle(requestuser1);

var pipeLine = new PipeLineBuilder()
    .AddPipe(exceptionHandlingPipe.Handle)
     .AddPipe(authenticationPipe.Handle)
    .AddPipe(endpointPipe.Handle)
    .Build(request1);

"\n\n".Dump();

var pipeLine2 = new PipeLineBuilder()
    .AddPipe(exceptionHandlingPipe.Handle)
     .AddPipe(authenticationPipe.Handle)
    .AddPipe(endpointPipe.Handle)
    .Build(request2);


