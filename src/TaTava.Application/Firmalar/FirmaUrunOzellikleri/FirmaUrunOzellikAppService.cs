using System.Linq;
using System.Threading.Tasks;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Firmalar.FirmaUrunOzellik;
using TaTava.Firmalar.FirmaUrunOzellikleri.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Firmalar.FirmaUrunOzellikleri
{
    public class FirmaUrunOzellikAppService : BaseAppService, IFirmaUrunOzellikAppService
    {
        private readonly IRepository<FirmaUrunOzellik, long> _firmaUrunOzellikRepository;

        public FirmaUrunOzellikAppService(IRepository<FirmaUrunOzellik, long> firmaUrunOzellikRepository)
        {
            _firmaUrunOzellikRepository = firmaUrunOzellikRepository;
        }

        public async Task<ServiceResult<IQueryable<FirmaUrunOzellikListOutputDto>>> FirmaUrunOzellikleri(GetAllFirmUrunOzellikInput input)
        {
            var firmaUrunOzellikleri = await _firmaUrunOzellikRepository.GetQueryableAsync(firmaUrunOzellik => firmaUrunOzellik.FirmaId == input.FirmaId && firmaUrunOzellik.DetayTipi == DetayTypes.Combo && firmaUrunOzellik.UrunId == input.UrunId, firmaUrunOzellik => firmaUrunOzellik.UrunOzellik);

            // Bu şekilde yaparsan veritabanında ki tüm sorguları atabilirsin. Örn: Where, Any, etc.
            // firmaUrunOzellikleri.Where(firmaUrunOzellik => firmaUrunOzellik.FirmaId == input.FirmaId);
            // firmaUrunOzellikleri.Any(firmaUrunOzellik => firmaUrunOzellik.FirmaId == input.FirmaId);


            return new ServiceResult<IQueryable<FirmaUrunOzellikListOutputDto>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, firmaUrunOzellikleri.Count(), "Firma Ürün Özellik"),
                Object = firmaUrunOzellikleri.ToFirmaUrunOzellikListOutputDto()
            };
        }
    }
}