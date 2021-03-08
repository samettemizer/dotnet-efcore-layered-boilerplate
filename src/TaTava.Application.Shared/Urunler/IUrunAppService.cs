using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared;
using TaTava.Urunler.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Urunler
{
    public interface IUrunAppService : IApplicationService
    {
        Task<ServiceResult<IQueryable<UrunListOutputDto>>> Urunler(GetAllUrunInput input);
    }
}