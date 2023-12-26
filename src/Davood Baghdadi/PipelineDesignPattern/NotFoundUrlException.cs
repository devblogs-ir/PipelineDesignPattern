using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    public  class NotFoundUrlException:Exception
    {
        public NotFoundUrlException() : base("Error 404 : This Url does not Exist!") 
        {
                
        }
    }
}
