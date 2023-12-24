using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineProject.ClassLib;
public class ProductController
{
    public void ListOfAllProducts(HttpContext httpContext)
    {
        "products".Dump();
    }
}

