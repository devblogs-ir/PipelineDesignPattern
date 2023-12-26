using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    public class GeoLocationException : Exception
    {
        public GeoLocationException(string location) : base(string.Format("Service in {0} is resticted",location))
        {
           
        }

    }
}
