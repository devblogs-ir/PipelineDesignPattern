using Dumpify;
using PipelineDesignPattern;

IList<CliOption> ExtractOptions(string[] args)
{
    var options = new List<CliOption>();

    for (int i = 0; i < args.Length; i += 2)
    {
        if (args[i].StartsWith("-"))
        {
            CliOption option = new(args[i][1..], args[i + 1]);
            options.Add(option);
        }
    }
    return options;
}

var options = ExtractOptions(args);

var ip = options.FirstOrDefault(option => option.Name == "ip");
if (ip is null)
{
    "Haven't Specified IP with -ip option".Dump();
    return;
}

var url = options.FirstOrDefault(option => option.Name == "url");

if (url is null)
{
    "Haven't Specified Url with -url option".Dump();
    return;
}

HttpContext request = new()
{
    Id = 1,
    IpAdrress = ip.Value,
    Request = new()
    {
        Url = url.Value
    }
};

new PipelineDirector().Process(request);