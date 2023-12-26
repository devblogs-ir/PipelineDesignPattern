using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPatternExp
{
    public class ProductsController
    {
        public void GetAll()
        {
            "Return All Products".Dump();
        }

        public void GetProductById(int id)
        {
            var products = new List<string>()
            {
                "A#1",
                "A#2",
                "A#3"
            };

            $"Product: {products[id]}".Dump();
        }
    }
}
