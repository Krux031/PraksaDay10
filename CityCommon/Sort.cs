using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCommon
{
    public class Sort
    {
        public string SortType { get; set; }

        public string GetQuery()
        {
            return ("order by naziv " + SortType);
        }
    }
}
