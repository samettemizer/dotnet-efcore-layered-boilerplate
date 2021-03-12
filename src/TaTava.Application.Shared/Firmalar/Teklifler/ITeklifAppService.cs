using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared;
using TaTava.Firmalar.Teklifler.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Firmalar.Teklifler
{
    public interface ITeklifAppService : IApplicationService
    {
        Task<ServiceResult<IQueryable<TeklifListOutputDto>>> Teklifler();
        Task<ServiceResult<TeklifListOutputDto>> TeklifEkle(TeklifInputDto input);
    }
}