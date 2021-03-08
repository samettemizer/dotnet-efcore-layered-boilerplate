using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaTava.Firmalar.Sektorler;
using TaTava.Firmalar.Sektorler.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Web.Host.Controllers
{
    public class SektorlerController : BaseApiController
    {
        private readonly ISektorAppService _sektorAppService;

        public SektorlerController(ISektorAppService sektorAppService)
        {
            _sektorAppService = sektorAppService;
        }

        [HttpGet]
        public async Task<ServiceResult<IQueryable<SektorListOutputDto>>> Get()
        {
            return await _sektorAppService.Sektorler();
        }
    }
}