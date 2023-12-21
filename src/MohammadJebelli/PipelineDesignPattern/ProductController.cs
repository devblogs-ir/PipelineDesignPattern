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
        public void GetAllUser(HttpContext context)
        {
            $"Ip: {context.IP}".Dump("Return all users");
        }
        public void GetUserById(HttpContext context)
        {
            $"Ip: {context.IP}".Dump("Return user by id");
        }
    }
}
