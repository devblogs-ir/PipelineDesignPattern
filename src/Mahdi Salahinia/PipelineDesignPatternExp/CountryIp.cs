using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPatternExp
{
    public class CountryIp
    {
        public List<string> IranIps { get; set; }
        public List<string> AmericaIps { get; set; }

        public CountryIp()
        {
            IranIps = new List<string>()
            {
                "192.168.22.7",
                "192.168.22.8",
                "192.168.22.9",
                "192.168.22.4"
            };

            AmericaIps = new List<string>()
            {
                "1.32.232.0",
                "2.16.55.0",
                "2.16.203.1",
            };
        }
    }
}
