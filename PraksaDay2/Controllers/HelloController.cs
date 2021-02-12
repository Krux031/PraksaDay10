using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using CityServiceCommon;
using CityModelCommon;
using CityModel;
using CityCommon;
using CityService;
using System.Threading.Tasks;
using AutoMapper;

namespace PraksaDay2.Controllers
{
    [RoutePrefix("api/Hello")]
    public class HelloController : ApiController
    {
        protected IService service;
        protected IMapper mapper;

        public HelloController(IService serv, IMapper map)
        {
            this.service = serv;
            this.mapper = map;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            ICity result;
            GetViewModel view;

            result = await service.GetCity(id);

            view = mapper.Map<ICity, GetViewModel>(result);

            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "No content");
            }

        }

        [HttpGet]
        [Route("Get/All")]
        public async Task<HttpResponseMessage> GetAll([FromUri] Pagination page, [FromUri] Filter filter, [FromUri] Sort sort)
        {
            List<ICity> results;
            List<GetViewModel> view = new List<GetViewModel>();

            results = await service.GetAllCity(page, filter, sort);

            if (results != null)
            {
                foreach (City rez in results)
                {
                    view.Add(mapper.Map<ICity, GetViewModel>(rez));
                }
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "No content");
            }
        }

        [HttpDelete]
        [Route("Delete/Resident/{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            if (await service.DeleteResident(id) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }
        }

        [HttpPost]
        [Route("Post/Resident")]
        public async Task<HttpResponseMessage> Post([FromBody] PostViewModel res)
        {
            IResidents resident;

            resident = mapper.Map<PostViewModel, IResidents>(res);

            if (await service.PostResident(resident) == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Bad Request");
            }
        }
    }
}
