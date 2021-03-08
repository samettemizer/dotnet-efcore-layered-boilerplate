using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared;
using TaTava.Firmalar.Sektorler.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Firmalar.Sektorler
{
    public interface ISektorAppService : IApplicationService
    {
        Task<ServiceResult<IQueryable<SektorListOutputDto>>> Sektorler();
    }
}