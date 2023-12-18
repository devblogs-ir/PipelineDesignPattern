using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomePipeLine
{
    public class Framework
    {


        private List<string> IranIP = new List<string>
        {
            "2.144.0.0",
            "31.7.88.0",
            "46.143.244.0",
            "62.32.49.240",
            "109.230.251.0"
        };

        private List<string> USAIP = new List<string>
        {
            "1.32.232.0",
            "2.16.55.0",
            "2.16.203.1",
            "2.255.254.78",
            "3.2.38.64"
        };

        public void ExceptionHandling(Action action, string ip)
        {
            "Check IP".Dump();

            if (IranIP.Any(c => c == ip))
            {
                "This is Iran IP, Access Denied".Dump();
            }
            else
            {
                "You Have Access".Dump();
                action();
            }

        }

        public void Authentication(Action action)
        {

            "############".Dump();
            "Start Authentication".Dump();

            action();

            "End Authentication".Dump();

        }
    }
}
