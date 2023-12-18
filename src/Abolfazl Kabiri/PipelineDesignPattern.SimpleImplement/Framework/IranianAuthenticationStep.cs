using Dumpify;
using PipelineDesignPattern.SimpleImplement.Pipeline;
using System.Net;

namespace PipelineDesignPattern.SimpleImplement.Framework
{
    public class IranianAuthenticationStep<T> : IEndPoindPipelineStep<T>
    {
        public Func<T> Func { get; set; }

        public void Exceute(IPipelineContext context)
        {

            "Starting auth".Dump();
            IPAddress parsedIpAddress;
            IPAddress.TryParse(context.RequestIpAddress, out parsedIpAddress);
            if (parsedIpAddress.ToString().Equals(context.RequestIpAddress))
            {
                if (context.RequestIpAddress.Split('.')[0].Equals("194")) // sample for iranian ip range
                {
                    Func();
                    "End auth".Dump();
                }
                else
                    throw new InvalidOperationException("request is not valid. invalid country");
            }
            else
            {
                throw new InvalidCastException("Ip address is not valid");
            }

        }

    }
}
