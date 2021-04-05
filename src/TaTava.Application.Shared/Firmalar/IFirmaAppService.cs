using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared;
using TaTava.Firmalar.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Firmalar
{
    public class query
    {
        public string unvan { get; set; }
        public string yetkiliSoyad { get; set; }
    }
    
    public interface IFirmaAppService : IApplicationService
    {
        Task<ServiceResult<IQueryable<FirmaOutputDto>>> FirmaListesi(query query = null);
        Task<ServiceResult<FirmaOutputDto>> FirmeEkle(FirmaInputDto input);
        Task<ServiceResult<FirmaOutputDto>> FirmaOge(int id);
    }
}