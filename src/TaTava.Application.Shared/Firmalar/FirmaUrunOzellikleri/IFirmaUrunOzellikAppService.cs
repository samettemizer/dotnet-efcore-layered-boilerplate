using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared;
using TaTava.Firmalar.FirmaUrunOzellikleri.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Firmalar.FirmaUrunOzellikleri
{
    public interface IFirmaUrunOzellikAppService : IApplicationService
    {
        Task<ServiceResult<IQueryable<FirmaUrunOzellikListOutputDto>>> FirmaUrunOzellikleri(GetAllFirmUrunOzellikInput input);
    }
}