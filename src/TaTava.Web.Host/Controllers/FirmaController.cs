using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaTava.Firmalar;
using TaTava.Firmalar.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Web.Host.Controllers
{
    public class FirmaController : BaseApiController
    {
        private readonly IFirmaAppService _firmaAppService;

        public FirmaController(IFirmaAppService firmaAppService)
        {
            _firmaAppService = firmaAppService;
        }

        [HttpGet]
        public async Task<ServiceResult<IQueryable<FirmaOutputDto>>> Get([FromQuery]query query)
        {
            return await _firmaAppService.FirmaListesi(query);
        }
        
        [HttpGet("{id}")]
        public async Task<ServiceResult<FirmaOutputDto>> Get(int id)
        {
            return await _firmaAppService.FirmaOge(id);
        }

        [HttpPost]
        public async Task<ServiceResult<FirmaOutputDto>> Post(FirmaInputDto input)
        {
            return await _firmaAppService.FirmeEkle(input);
        }
    }
}