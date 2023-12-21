using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPatternExp
{
    public class CountryIp
    {
        public IReadOnlyList<string> IranIps { get; set; } = ["192.168.22.7", "192.168.22.8", "192.168.22.9"];
        public IReadOnlyList<string> AmericaIps { get; set; } = ["1.32.232.0", "2.16.55.0", "2.16.203.1"];
    }
}
