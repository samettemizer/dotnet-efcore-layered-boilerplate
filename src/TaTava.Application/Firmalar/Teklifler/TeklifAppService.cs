using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared.Firmalar.Teklifler;
using TaTava.Application.Shared.Firmalar.Teklifler.Dtos;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Firmalar.Teklifler;
using TaTava.Firmalar.Teklifler.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Application.Firmalar.Teklifler
{
    public class TeklifAppService : ITeklifAppService
    {
        private readonly IRepository<Teklif, int> _teklifRepository;

        public Task<ServiceResult<TeklifInsertOutputDto>> FirmeEkle(TeklifInputDto input)
        {
            return null;
        }

        public async Task<ServiceResult<IQueryable<TeklifListOutputDto>>> Teklifler()
        {
            var teklifler = await _teklifRepository.GetQueryableAsync();

            return new ServiceResult<IQueryable<TeklifListOutputDto>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, teklifler.Count(), "Teklif"),
                Object = teklifler.ToTeklifListOutput()
            };
        }
    }
}