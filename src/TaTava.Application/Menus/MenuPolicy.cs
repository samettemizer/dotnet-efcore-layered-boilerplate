using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Extensions;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;

namespace TaTava.Menus
{
    public class MenuPolicy : BasePolicy
    {
        private readonly IRepository<Menu, Guid> _menuRepositorysitory;
        public MenuPolicy(IRepository<Menu, Guid> menuRepository)
        {
            _menuRepositorysitory = menuRepository;
        }

        public async Task<ServiceResult> SameTitle(string title)
        {
            var isThisTitleUsedAnySomeone = await _menuRepositorysitory.Any(menu => menu.Title == title && !menu.IsDeleted);
            if (isThisTitleUsedAnySomeone)
            {
                var errorMessage = $"Sistemde bu Menu adında menu bulunmaktadır. Menu adı: {title}";
                return new ServiceResult(Status.Warning) { Message = errorMessage };
            }
            return new ServiceResult(Status.Success);
        }
        public async Task<ServiceResult> IsMenuExistById(EntityDto<Guid> input)
        {
            var zeroCheck = input.Id == new Guid() ? false : true;
            if (!zeroCheck) return new ServiceResult(Status.Warning) { Message = ServiceMessages.RecordFound };

            var isMenuExistById = await _menuRepositorysitory.Any(menu => menu.Id == input.Id);

            if (!isMenuExistById)
            {
                var errorMessage = $"Sistem vermiş olduğunuz id ile kayıt menü bulunamadı, lütfen kontrol ediniz. Menü Id: {input.Id}";
                return new ServiceResult(Status.Error) { Message = errorMessage };
            }
            return new ServiceResult(Status.Success);
        }
        public async Task<ServiceResult> SameMenuOrder(Menu menuEntity)
        {
            var isMenuHasUpperMenu = menuEntity.UpperMenuId != Guid.NewGuid();

            var menusToControlTheirOrder = await _menuRepositorysitory.GetQueryableAsync(menu => !menu.IsDeleted && menu.Id != menuEntity.Id && menu.MenuOrder == menuEntity.MenuOrder);
            menusToControlTheirOrder = menusToControlTheirOrder.WhereIf(isMenuHasUpperMenu, menu => menu.UpperMenuId == menuEntity.UpperMenuId);

            if (menusToControlTheirOrder.Count() > 0)
            {
                var errorMessage = $"Bu üst menude ayni menu sirasindan bulunmaktadir. Üst menu sirasi: {menuEntity.UpperMenuId} ve Menu sirasi:{menuEntity.MenuOrder} ";

                return new ServiceResult(Status.Error) { Message = errorMessage };
            }

            return new ServiceResult(Status.Success);

            #region - Old
            // if (menuEntity.UpperMenuId != null)
            // {
            //     var isThereUpperMenu = await _menuRepositorysitory.Any(menu => menu.UpperMenuId == menuEntity.UpperMenuId && menu.MenuOrder == menuEntity.MenuOrder);

            //     if (isThereUpperMenu)
            //     {
            //         var updateMenu = await _menuRepositorysitory.Any(menu => menu.UpperMenuId == menuEntity.UpperMenuId && menu.MenuOrder == menuEntity.MenuOrder && menu.Id == menuEntity.Id);
            //         if (updateMenu)
            //             return new ServiceResult(Status.Success);

            //         var errorMessage = $"Bu üst menude ayni menu sirasindan bulunmaktadir. Üst menu sirasi: {menuEntity.UpperMenuId} ve Menu sirasi:{menuEntity.MenuOrder} ";
            //         return new ServiceResult(Status.Error) { Message = errorMessage };
            //     }
            //     return new ServiceResult(Status.Success);
            // }

            // var isThereMenuOrder = await _menuRepositorysitory.Any(menu => menu.MenuOrder == menuEntity.MenuOrder);

            // if (isThereMenuOrder)
            // {

            //     var errorMessage = $"Bu menu sirasindan bulunmaktadir. Ayni menu sirasindan {isThereMenuOrder} adet bulunmaktadir. Menu sirasi: {menuEntity.MenuOrder} ";
            //     return new ServiceResult(Status.Error) { Message = errorMessage };
            // }
            // return new ServiceResult(Status.Success);
            #endregion
        }
    }
}