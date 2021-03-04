using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.Core.Shared.Extensions;
using TaTava.EntityFrameworkCore.Extensions;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;
using TaTava.Menus.Dtos;

namespace TaTava.Menus
{
    public class MenuAppService : BaseAppService, IMenuAppService
    {
        private readonly IRepository<Menu, Guid> _menuRepository;
        private readonly MenuPolicy _menuPolicy;
        private readonly IUnitOfWork _unitOfWork;
        public MenuAppService(IRepository<Menu, Guid> menuRepository, MenuPolicy menuPolicy, IUnitOfWork unitOfWork)
        {
            _menuRepository = menuRepository;
            _menuPolicy = menuPolicy;

            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult> DeleteMenu(EntityDto<Guid> input)
        {
            var isMenuExistById = await _menuPolicy.IsMenuExistById(new EntityDto<Guid> { Id = input.Id });

            if (isMenuExistById.IsFailed)
                return new ServiceResult(isMenuExistById.Status) { Message = isMenuExistById.Message };

            await _menuRepository.Delete(menu => menu.Id == input.Id);

            _unitOfWork.SaveChanges();

            return new ServiceResult(Status.Success) { Message = string.Format(ServiceMessages.DeleteSuccessful, "Menü") };
        }

        public async Task<ServiceResult<IQueryable<MenuListOutputDto>>> GetAllMenu()
        {
            var allMenus = await _menuRepository.GetQueryableAsync(menu => !menu.IsDeleted);

            return new ServiceResult<IQueryable<MenuListOutputDto>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, allMenus.Count(), "Menu"),
                Object = allMenus.ToMenuListEntity()
            };
        }

        public async Task<ServiceResult<MenuOutputDto>> GetMenuById(EntityDto<Guid> input)
        {
            var menuById = await _menuRepository.GetAsync(menu => !menu.IsDeleted && menu.Id == input.Id);

            if (menuById is null)
                return new ServiceResult<MenuOutputDto>(Status.Warning)
                {
                    Message = ServiceMessages.RecordNotFound
                };

            return new ServiceResult<MenuOutputDto>(Status.Success)
            {
                Object = menuById.ToMenuOutputDto(),
                Message = ServiceMessages.RecordFound
            };
        }

        public async Task<ServiceResult<MenuOutputDto>> InsertMenu(InsertMenuInputDto input)
        {
            if (!input.MenuOrder.Equals(0))
            {
                var isMenuOrderExist = await _menuPolicy.SameMenuOrder(input.ToInsertMenuInputEntity());

                if (isMenuOrderExist.IsFailed)
                    return new ServiceResult<MenuOutputDto>(isMenuOrderExist.Status) { Message = isMenuOrderExist.Message };
            }

            var isMenuTitleExist = await _menuPolicy.SameTitle(input.Title);

            if (isMenuTitleExist.IsFailed)
                return new ServiceResult<MenuOutputDto>(Status.Warning) { Message = isMenuTitleExist.Message };

            try
            {
                input.Url = input.Title.ToSeoFriendlyUrl();

                if (input.MenuOrder == 0)
                {
                    var menuHasUpperMenu = input.UpperMenuId != Guid.NewGuid();
                    var menus = await _menuRepository.GetQueryableAsync(menu => !menu.IsDeleted);
                    menus = menus.WhereIf(menuHasUpperMenu, menu => menu.UpperMenuId == input.UpperMenuId);
                    menus = menus.WhereIf(!menuHasUpperMenu, menu => menu.UpperMenuId == null || menu.UpperMenuId == Guid.NewGuid());

                    input.MenuOrder = menus.Count() + 1;

                }

                var entity = input.ToInsertMenuInputEntity();

                await _menuRepository.InsertAsync(entity);

                _unitOfWork.SaveChanges();

                return new ServiceResult<MenuOutputDto>(Status.Success)
                {
                    Message = string.Format(ServiceMessages.InsertSuccessful, "Menu"),
                    Object = entity.ToMenuOutputDto()
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<MenuOutputDto>(Status.Error)
                {
                    Message = string.Format("Kategori kaydı sırasında bir hata oluştu. Sebebi; {0}", e.Message)
                };
            }

        }

        public async Task<ServiceResult> UpdateMenuInput(UpdateMenuInputDto input)
        {
            var isMenuExistById = await _menuPolicy.IsMenuExistById(new EntityDto<Guid> { Id = input.Id });

            if (isMenuExistById.IsFailed)
                return new ServiceResult(isMenuExistById.Status) { Message = isMenuExistById.Message };

            var menuToUpdate = await _menuRepository.GetAsync(menu => menu.Id == input.Id);

            var isThereAnyMenuInTheSameOrder = await _menuPolicy.SameMenuOrder(menuToUpdate.ToUpdateMenuInputEntity(input));

            if (isThereAnyMenuInTheSameOrder.IsFailed)
                return new ServiceResult(isThereAnyMenuInTheSameOrder.Status) { Message = isThereAnyMenuInTheSameOrder.Message };

            try
            {
                input.Url = input.Title.ToSeoFriendlyUrl();

                await _menuRepository.Update(menuToUpdate.ToUpdateMenuInputEntity(input));

                _unitOfWork.SaveChanges();

                return new ServiceResult(Status.Success) { Message = $"{input.Title} adlı menü güncellemiştir." };
            }
            catch (Exception e)
            {
                return new ServiceResult(Status.Error)
                {
                    Message = string.Format($"{input.Title} adlı menu bilgilerini düzenlerken bir hata oluştu. Sebebi;{0}", e.Message)
                };
            }
        }
    }
}
