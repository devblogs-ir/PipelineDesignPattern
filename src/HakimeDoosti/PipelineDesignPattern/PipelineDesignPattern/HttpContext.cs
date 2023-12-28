using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    public class HttpContext
    {
        public string IP { get; set; }

        /// <summary>
        /// ControllerName/ActionName
        /// </summary>
        public string Url { get; set; }
    }
}
