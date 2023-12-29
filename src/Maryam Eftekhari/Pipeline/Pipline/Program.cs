using Pipeline;
using Pipeline.Context;

ProductsController productsController = new();
FrameWork frameWork = new();
HttpContext iranContext = new()
{
    IP = "2.144.0.0"
};

HttpContext unitedStateContext = new()
{
    IP = "3.128.0.0"
};

frameWork.ExceptionHandling(
    iranContext, (HttpContext) => frameWork.Athentication(iranContext, productsController.GetAllProducts));

frameWork.ExceptionHandling(
    unitedStateContext, (HttpContext) => frameWork.Athentication(unitedStateContext, productsController.GetAllProducts));





