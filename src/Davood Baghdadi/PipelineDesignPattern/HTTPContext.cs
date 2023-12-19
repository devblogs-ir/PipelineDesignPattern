using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    public class HTTPContext
    {
        public int UserId {  get; set; }
        public string IP { get; set; }

        public string Destination { get; set; }
    }
}
