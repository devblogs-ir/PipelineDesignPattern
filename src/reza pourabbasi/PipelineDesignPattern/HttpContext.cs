using System.Runtime.InteropServices;

namespace PipelineDesignPattern;

 
public class HttpContext
{
    public required string IP { get; set; }

    // Products/GetAll
    public string Url { get; set; }
}
