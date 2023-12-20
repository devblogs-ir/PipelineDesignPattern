

using PipelineProject.ClassLib;

ProductController product = new();
HttpContext user1 = new() { IP = "Iran" };
HttpContext user2 = new() { IP = "UAE" };
HttpContext user3 = new() { IP = "Canada" };
Framework framework = new();


framework.IPAuthentication(user1,
    (user1) 
    => framework.ExceptionHandling(user1, ((user1) 
    => product.ListOfAllProducts(user1))));

framework.IPAuthentication(user2,
    (user2) 
    => framework.ExceptionHandling(user2, ((user2) 
    => product.ListOfAllProducts(user2))));

framework.IPAuthentication(user1,
    (user3) => 
    framework.ExceptionHandling(user3, ((user3) 
    => product.ListOfAllProducts(user3))));
