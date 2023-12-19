using Dumpify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    public class Controller
    {
        public void Get(HTTPContext context)
        {
            if (context.Destination == "product" && context.UserId == 1)
            {
                "List of Products Displays".Dump();
            }
            else if (context.Destination == "order" && context.UserId == 1)
            {
                "List of Orders Displays".Dump();
            }
            else if (context.UserId == 1)
            {
                "You are not Logged In!".Dump();
            }
        }

    }
    
}
