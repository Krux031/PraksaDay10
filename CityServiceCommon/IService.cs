using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityModelCommon;
using CityRepositoryCommon;
using CityModel;
using CityCommon;

namespace CityServiceCommon
{
    public interface IService
    {
        Task<ICity> GetCity(int id);

        Task<List<ICity>> GetAllCity(Pagination page, Filter filter, Sort sort);

        Task<bool> DeleteResident(int id);

        Task<bool> PostResident(IResidents resident);
    }

}
