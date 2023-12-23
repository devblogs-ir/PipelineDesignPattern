using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    public class AccessingFromBannedCountryException : Exception
    {
        public AccessingFromBannedCountryException(string countryName) : base(Messages.AccessingFromBannedCountryException(countryName))
        {

        }
    }
}
