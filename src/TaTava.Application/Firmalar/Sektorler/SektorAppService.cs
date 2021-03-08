using System.Linq;
using System.Threading.Tasks;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Firmalar.Sektorler;
using TaTava.Firmalar.Sektorler.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Application.Firmalar.Sektorler
{
    public class SektorAppService : ISektorAppService
    {
        private readonly IRepository<Sektor, short> _sektorRepository;

        public SektorAppService(IRepository<Sektor, short> sektorRepository)
        {
            _sektorRepository = sektorRepository;
        }

        public async Task<ServiceResult<IQueryable<SektorListOutputDto>>> Sektorler()
        {
            var sektorler = await _sektorRepository.GetQueryableAsync();

            return new ServiceResult<IQueryable<SektorListOutputDto>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, sektorler.Count(), "Sektör"),
                Object = sektorler.ToSektorListOutput()
            };
        }
    }
}