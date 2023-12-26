using PipelineDesignPattern;


HttpContext iranRequest = new()
{
    Id = 1,
    IpAdrress = "83.241.2.10",
    Request = new HttpRequest { Url = "Product/GetUsers" }
};

HttpContext usRequest = new()
{
    Id = 2,
    IpAdrress = "64.21.13.94",
    Request = new HttpRequest { Url = "Product/GetUsers" }
};

HttpContext getUserByIdRequest = new()
{
    Id = 3,
    IpAdrress = "64.21.13.94",
    Request = new HttpRequest { Url = "Product/GetUserById/2" }
};

HttpContext invalidUrlRequestFormat = new()
{
    Id = 4,
    IpAdrress = "64.21.13.94",
    Request = new HttpRequest { Url = "Product/GetUser/name/2" }
};


HttpContext invalidEndPointRequest = new()
{
    Id = 5,
    IpAdrress = "64.21.13.94",
    Request = new HttpRequest { Url = "Product/GetUserByName/2" }
};


IPipelineDirector pipelineDirector = new PipelineDirector();

pipelineDirector.Process(iranRequest);
pipelineDirector.Process(usRequest);
pipelineDirector.Process(getUserByIdRequest);
pipelineDirector.Process(invalidUrlRequestFormat);
pipelineDirector.Process(invalidEndPointRequest);