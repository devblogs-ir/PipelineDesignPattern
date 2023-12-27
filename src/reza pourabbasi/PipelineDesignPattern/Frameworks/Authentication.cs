
namespace PipelineDesignPattern.Frameworks;
public class Authentication : PipeBase
{
    public override async Task HandleAsync(HttpContext httpContext)
    {
        if (httpContext is null)
            throw new IPNotProvideException("ip is not provide");
        else if (httpContext.IP is "85.185.20.177")
            throw new InvalidIPException("invalid IP");

        await _next!(httpContext);
    }
}
