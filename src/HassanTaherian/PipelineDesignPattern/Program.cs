using Dumpify;
using PipelineDesignPattern;

Framework framework = new();
ProductController productController = new();

void ProcessRequest(HttpContext context)
{
    $"Processing Request {context.ID}".Dump();

    framework.ExceptionHandling(
        context,
        (context) =>
        {
            framework.Routing(
                context,
                (context) =>
                {
                    framework.Auth(context, (context) => ProductController.GetUsers());
                });
        });

    $"End Process of Request {context.ID}".Dump();
}

HttpContext iranRequest = new()
{
    ID = 1,
    IP = 83
};

HttpContext usRequest = new()
{
    ID = 2,
    IP = 100
};



ProcessRequest(iranRequest);
ProcessRequest(usRequest);