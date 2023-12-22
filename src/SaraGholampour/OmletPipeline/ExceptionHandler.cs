namespace OmletPipeline;

public class ExceptionHandler
{
    public void Handle(Action func)
    {
        try
        {
            func();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
