using PipeLineDesignPattern;

Framework framework = new Framework();
CountriesController countryController = new CountriesController();

var iran = new HttpContext { IP = "10.10.1.1" };
var america = new HttpContext { IP = "10.10.1.2" };


framework.ExceptionHandling(iran, (context) => framework.Authentication(context, countryController.GetIP));
framework.ExceptionHandling(america, (context) => framework.Authentication(context, countryController.GetIP));

