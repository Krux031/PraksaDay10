using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityServiceCommon;
using CityModelCommon;
using CityRepositoryCommon;
using CityModel;
using CityRepository;
using CityCommon;

namespace CityService
{
    public class Service : IService
    {
        protected IRepository repository;

        public Service(IRepository repo)
        {
            this.repository = repo;
        }

        public async Task<ICity> GetCity(int id)
        {
            return await repository.GetCityRep(id);
        }

        public async Task<List<ICity>> GetAllCity(Pagination page, Filter filter, Sort sort)
        {
            return await repository.GetAllCityRep(page, filter, sort);
        }

        public async Task<bool> DeleteResident(int id)
        {
            return await repository.DeleteresidentRep(id);
        }

        public async Task<bool> PostResident(IResidents resident)
        {
            return await repository.PostResidentRep(resident);
        }
    }
}
