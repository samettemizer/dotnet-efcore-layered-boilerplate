using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared.Firmalar.Teklifler.Dtos;
using TaTava.Firmalar.Teklifler.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Application.Shared.Firmalar.Teklifler
{
    public interface ITeklifAppService : IApplicationService
    {
        Task<ServiceResult<IQueryable<TeklifListOutputDto>>> Teklifler();
        Task<ServiceResult<TeklifInsertOutputDto>> FirmeEkle(TeklifInputDto input);
    }
}