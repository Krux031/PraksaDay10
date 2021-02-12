using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCommon
{
    public class Filter
    {
        public string FilterName { get; set; }

        public string GetQuery()
        {
            return "where naziv = '" + FilterName + "' ";
        }
    }
}
