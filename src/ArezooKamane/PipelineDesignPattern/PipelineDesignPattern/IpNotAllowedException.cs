using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    public class IpNotAllowedException : Exception
    {
        public string Ip { get; }
        public IpNotAllowedException() { }

        public IpNotAllowedException(string ip) : base(string.Format("{0} this ip is not allowed", ip)) { }

        public IpNotAllowedException(string message, string ip) : base(message)
        {
            this.Ip = ip;
        }

        public IpNotAllowedException(string ip, string message, Exception innerException) : base(message,
            innerException)
        {
            this.Ip = ip;
        }
    }
}
