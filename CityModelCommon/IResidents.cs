using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityModelCommon
{
    public interface IResidents
    {
        int Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        int Pbr { get; set; }
        string Gender { get; set; }
    }
}
