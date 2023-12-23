using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDesignPattern
{
    internal class CountryRepository : ICountryRepository
    {
        // Assume that this data will genertate by some sort of Data Access layer
        public IEnumerable<Country> FetchAll()
        {
            return new List<Country> {
                new("Iran", 83, true),
                new("Russia", 31, true),
                new("US", 64, false),
                new("Finland", 86, false),
                new("Sudan", 43, true),
                new("North Korea", 13, true)
            };
        }
    }
}
