using Dumpify;
using PipelineDesignPattern.SimpleImplement.Pipeline;
using System.Net;

namespace PipelineDesignPattern.SimpleImplement.Framework;

public class AmericanAuthenticationStep<T> : IEndPointPipelineStep<T>
{
    public Func<T> Func { get; set; }
    public void Exceute(IPipelineContext context)
    {
        "Starting auth".Dump();
        ValidateIpAddress(context);
        Func();
        "End auth".Dump();
    }
    private bool ValidateIpAddress(IPipelineContext context)
    {
        IPAddress parsedIpAddress;
        IPAddress.TryParse(context.RequestIpAddress, out parsedIpAddress);
        if (!parsedIpAddress.ToString().Equals(context.RequestIpAddress))
            throw new InvalidCastException("Ip address is not valid");
        else
        {
            if (!context.RequestIpAddress.Split('.')[0].Equals("200")) // sample for american ip range
                throw new InvalidOperationException("request is not valid. invalid country");
            return true;
        }
    }
}
