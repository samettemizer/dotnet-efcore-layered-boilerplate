using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaTava.Firmalar.FirmaUrunOzellikleri;
using TaTava.Firmalar.FirmaUrunOzellikleri.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Web.Host.Controllers
{
    public class FirmaUrunOzellikController : BaseApiController
    {
        private readonly IFirmaUrunOzellikAppService _firmaUrunOzellikAppService;

        public FirmaUrunOzellikController(IFirmaUrunOzellikAppService firmaUrunOzellikAppService)
        {
            _firmaUrunOzellikAppService = firmaUrunOzellikAppService;
        }

        [HttpGet]
        public async Task<ServiceResult<IQueryable<FirmaUrunOzellikListOutputDto>>> Get([FromQuery] GetAllFirmUrunOzellikInput input)
        {
            return await _firmaUrunOzellikAppService.FirmaUrunOzellikleri(input);
        }
    }
}