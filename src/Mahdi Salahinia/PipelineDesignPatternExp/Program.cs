using PipelineDesignPatternExp;

var framework = new Framework();
var ipController = new IpController();

var iranIp = "192.168.22.7";
var americaIp = "1.32.232.0";

framework.ExceptionHandling(() => framework.Authentication(() => ipController.GetMyIp(americaIp)), americaIp);