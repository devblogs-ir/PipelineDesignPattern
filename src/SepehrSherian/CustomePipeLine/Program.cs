using CustomePipeLine;




string IranIP = "109.230.251.0";
string USAIP = "3.2.38.64";



IPController iPController = new();
Framework framework = new();


framework.ExceptionHandling(()=> framework.Authentication(() => iPController.GetIP(IranIP)), IranIP);

framework.ExceptionHandling(() => framework.Authentication(() => iPController.GetIP(USAIP)), USAIP);




