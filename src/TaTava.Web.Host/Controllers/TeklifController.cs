using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaTava.Firmalar.Teklifler;
using TaTava.Firmalar.Teklifler.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Web.Host.Controllers
{
    public class TeklifController : BaseApiController
    {
        private readonly ITeklifAppService _teklifAppService;

        public TeklifController(ITeklifAppService teklifAppService)
        {
            _teklifAppService = teklifAppService;
        }


        [HttpGet]
        public async Task<ServiceResult<IQueryable<TeklifListOutputDto>>> Get()
        {
            return await _teklifAppService.Teklifler();
        }

        [HttpPost]
        public async Task<ServiceResult<TeklifListOutputDto>> Post(TeklifInputDto input)
        {
            return await _teklifAppService.TeklifEkle(input);
        }
    }
}