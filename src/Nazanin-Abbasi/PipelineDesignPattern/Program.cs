//The code demonstrates how the Pipeline Design Pattern can be used to handle exceptions and perform authentication in different contexts. 

using PipelineDesignPattern;

ProductController productController = new();

LoginPipeLine loginPipes = new();

HttpContext irContext = new() { IP = 1 };

HttpContext usContext = new() { IP = 2 };

loginPipes.ExceptionHandling(irContext, (context) => loginPipes.Authentication(context, productController.GetAllProduct));

loginPipes.ExceptionHandling(usContext, (context) => loginPipes.Authentication(context, productController.GetAllProduct));