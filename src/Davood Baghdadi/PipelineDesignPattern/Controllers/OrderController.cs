using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern.Controllers
{
    public  class OrderController
    {
        private readonly HTTPContext _httpContext;

        public OrderController(HTTPContext httpContext)
        {
            _httpContext = httpContext;
        }

        public void GetAll()
        {
            ("Get All Orders").Dump();

        }
    }
}
