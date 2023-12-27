
namespace PipelineDesignPattern.Frameworks;
public class ExceptionHandling : PipeBase
{
    public override async Task HandleAsync(HttpContext httpContext)
    {
        try
        {
            await _next!(httpContext);
        }
        catch (Exception ex) when (ex is IPNotProvideException)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex) when (ex is InvalidIPException)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
