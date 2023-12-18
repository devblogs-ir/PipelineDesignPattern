using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomePipeLine
{
    public class IPController
    {
        public string GetIP(string ip)
        {
            $"This is Your IP:{ip}".Dump();
            return ip;
        }
    }
}
