
using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    public class ProductController
    {
        private readonly HttpContext _context;

        public ProductController(HttpContext context)
        {
            _context = context;            
        }

        public void GetAll()
        {
            $"Return all users for IP: {_context.IP}".Dump();
        }
        public void GetById(HttpContext context)
        {
            "Return user by id".Dump();
        }
    }
}
