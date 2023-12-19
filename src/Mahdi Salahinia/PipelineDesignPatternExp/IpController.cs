using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPatternExp
{
    public class IpController
    {
        public void GetMyIp(string ip)
        {
            $"My Ip is {ip}".Dump();
        }
    }
}
