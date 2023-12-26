using PipelineDesignPattern;
using System.Reflection;

Framework framework = new();

HttpContext requestUser1 = new() {
    IP = "123.185.20.177" ,
    Url = "localhost:4545/Products/GetUserById/0"
};

HttpContext requestUser2 = new()
{
    IP = "123.185.20.177",
    Url = "localhost:4545/Products/GetUserById/1"
};
  
var pipeline = new PipelineBuilder()
                        .AddPipe(typeof(ExceptionHandlingPipe))
                        .AddPipe(typeof(AuthenticationPipe))
                        .AddPipe(typeof(EndPointPipe))
                        .Build();

pipeline.Handle(requestUser1);
pipeline.Handle(requestUser2);
pipeline.Handle(requestUser2);
pipeline.Handle(requestUser1);
pipeline.Handle(requestUser2);

