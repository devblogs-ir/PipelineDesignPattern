using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dumpify;

namespace PipelineDesignPattern
{
    public class ProductController
    {
        public void GetAllProducts(HttpContext httpContext)
        {
            "all products".Dump();
        }
    }
}
