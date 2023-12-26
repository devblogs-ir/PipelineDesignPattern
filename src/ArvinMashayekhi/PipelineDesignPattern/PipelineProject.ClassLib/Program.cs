

using PipelineProject.ClassLib;

ProductController product = new();
HttpContext user1 = new() { IP = "192.168.0.130" };

Framework framework = new();


framework.IPAuthentication(user1,
    (user1) 
    => framework.ExceptionHandling(user1, ((user1) 
    => product.ListOfAllProducts(user1))));
