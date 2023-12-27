
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
            Console.WriteLine("Return all users");
        }
        public void GetById()
        {
            Console.WriteLine("Return user by id");
        }
    }
}
