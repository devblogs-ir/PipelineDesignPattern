using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern.Controllers
{
    public class ProductController
    {
        private readonly HTTPContext _httpContext;

        public ProductController(HTTPContext httpContext)
        {
            _httpContext = httpContext;
        }
        public void GetAll()
        {
            ("Get All Products").Dump();
        }
    }
}
