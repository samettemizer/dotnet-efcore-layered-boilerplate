using System;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared;
using TaTava.Application.Shared.Dtos;
using TaTava.Infrastructure;
using TaTava.Menus.Dtos;

namespace TaTava.Menus
{
    public interface IMenuAppService : IApplicationService
    {
        Task<ServiceResult<IQueryable<MenuListOutputDto>>> GetAllMenu();
        Task<ServiceResult<MenuOutputDto>> InsertMenu(InsertMenuInputDto input);
        Task<ServiceResult> UpdateMenuInput(UpdateMenuInputDto input);
        Task<ServiceResult> DeleteMenu(EntityDto<Guid> input);
        Task<ServiceResult<MenuOutputDto>> GetMenuById(EntityDto<Guid> input);
    }
}
