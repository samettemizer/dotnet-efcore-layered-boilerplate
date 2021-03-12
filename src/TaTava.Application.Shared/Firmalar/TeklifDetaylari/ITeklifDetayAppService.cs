using System.Threading.Tasks;
using TaTava.Application.Shared;
using TaTava.Firmalar.TeklifDetaylari.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Firmalar.TeklifDetaylari
{
    public interface ITeklifDetayAppService : IApplicationService
    {
         Task<ServiceResult<TeklifDetayOutputDto>> TeklifDetayEkle(TeklifDetayInputDto input);
    }
}