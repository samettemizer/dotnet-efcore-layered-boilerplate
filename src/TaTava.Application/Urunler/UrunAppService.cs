using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Urunler;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Extensions;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;
using TaTava.Urunler.Dtos;

namespace TaTava.Urunler
{
    public class UrunAppService : IUrunAppService
    {
        private readonly IRepository<Urun, short> _urunRepository;

        public UrunAppService(IRepository<Urun, short> urunRepository)
        {
            _urunRepository = urunRepository;
        }

        public async Task<ServiceResult<IQueryable<UrunListOutputDto>>> Urunler(GetAllUrunInput input)
        {
            var urunler = await _urunRepository.GetQueryableAsync();
            urunler = urunler.WhereIf(input.SektorId > default(short), urun => urun.SektorId == input.SektorId);

            return new ServiceResult<IQueryable<UrunListOutputDto>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, urunler.Count(), "Ürün"),
                Object = urunler.ToUrunListOutputDto()
            };
        }


    }
}