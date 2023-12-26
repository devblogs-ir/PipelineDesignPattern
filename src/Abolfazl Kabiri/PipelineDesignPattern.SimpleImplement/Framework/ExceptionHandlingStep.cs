using Dumpify;
using PipelineDesignPattern.SimpleImplement.CustomExceptions;
using PipelineDesignPattern.SimpleImplement.Pipeline;

namespace PipelineDesignPattern.SimpleImplement.Framework;

public class ExceptionHandlingStep : IPipe
{
    public Action<IPipelineContext> Next { get; set; }
    public void Invoke(IPipelineContext context)
    {
        try
        {
            "starting exception handling".Dump();
            Next(context);
        }
        catch (InvalidIpAddressException ex)
        {
            "Invalid ip address ".Dump(ex.Message);
        }
        catch (InaccessibilityException ex)
        {
            "Invalid request from ".Dump(ex.Message);
        }
        catch (UnknownIpAddressException ex)
        {
            "Ip address is unknown ".Dump(ex.Message);
        }
        catch (Exception ex)
        {
            "exception occurod".Dump(ex.Message);
        }
    }
}
