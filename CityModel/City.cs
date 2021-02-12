using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityModelCommon;

namespace CityModel
{
    public class City : ICity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
