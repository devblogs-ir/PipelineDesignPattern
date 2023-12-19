using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPatternExp
{
    public class Framework
    {
        private readonly Action _action;

        //CountryIp ips = new CountryIp()
        //{
        //    IranIps = new List<string>
        //    {
        //        "192.168.22.7",
        //        "192.168.22.8",
        //        "192.168.22.9",
        //        "192.168.22.4"
        //    },

        //    AmericaIps = new List<string>
        //    {
        //        "1.32.232.0",
        //        "2.16.55.0",
        //        "2.16.203.1",
        //    }
        //};

        public void ExceptionHandling(Action action, string ip)
        {
            var ips = new CountryIp();
            
            if (ips.IranIps.Contains(ip))
            {
                "Access Denied".Dump();
            }
            else
            {
                "Access is OK".Dump();
                action();
            }
        }

        public void Authentication(Action action)
        {
            "Start Authentication".Dump();

            action();

            "End Authentication".Dump();
        }
    }
}
