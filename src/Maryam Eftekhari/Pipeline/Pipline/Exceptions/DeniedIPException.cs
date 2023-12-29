using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.Exceptions
{
    [Serializable]
    public class DeniedIPException : Exception
    {
        public DeniedIPException()
        {
        }

        public override string Message =>
            $"{base.Message} Your IP is Denied.";
    }
}
