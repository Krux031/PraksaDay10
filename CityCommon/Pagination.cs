using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCommon
{
    public class Pagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string GetQueryP()
        {
            return (" OFFSET " + (PageNumber - 1) * PageSize + " ROWS FETCH NEXT " + PageSize + " ROWS ONLY");
        }
    }
}
