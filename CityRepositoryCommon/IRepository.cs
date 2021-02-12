using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityModelCommon;
using CityModel;
using CityCommon;

namespace CityRepositoryCommon
{
    public interface IRepository
    {
        Task<ICity> GetCityRep(int id);

        Task<List<ICity>> GetAllCityRep(Pagination page, Filter filter, Sort sort);

        Task<bool> DeleteresidentRep(int id);

        Task<bool> PostResidentRep(IResidents resident);
    }
}
