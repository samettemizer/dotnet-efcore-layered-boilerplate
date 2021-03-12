using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaTava.Infrastructure;
using TaTava.Urunler;
using TaTava.Urunler.Dtos;

namespace TaTava.Web.Host.Controllers
{
    public class UrunlerController : BaseApiController
    {
        private readonly IUrunAppService _urunlerAppService;

        public UrunlerController(IUrunAppService urunlerAppService)
        {
            _urunlerAppService = urunlerAppService;
        }

        [HttpGet]
        public async Task<ServiceResult<IQueryable<UrunListOutputDto>>> Get([FromQuery]GetAllUrunInput input)
        {
            return await _urunlerAppService.Urunler(input);
        }
    }
}