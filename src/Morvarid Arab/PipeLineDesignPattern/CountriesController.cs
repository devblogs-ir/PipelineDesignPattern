using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineDesignPattern
{
    public class CountriesController
    {
        public void GetIP(HttpContext context)
        {
            context.IP.Dump(label: "Your IP");
        }
    }
}
