using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Menus.Dtos;

namespace TaTava.Menus
{
    public static class MenuMapper
    {
        public static IQueryable<MenuListOutputDto> ToMenuListEntity(this IQueryable<Menu> menus)
        {
            return menus.Select(menuListOutput => new MenuListOutputDto
            {
                Id = menuListOutput.Id,
                Title = menuListOutput.Title,
                MenuOrder = menuListOutput.MenuOrder,
                Url = menuListOutput.Url,
                UpperMenuId = menuListOutput.UpperMenuId,
                IsActive = menuListOutput.IsActive
            });
        }
        public static Menu ToInsertMenuInputEntity(this InsertMenuInputDto input)
        {
            return new Menu(input.Title, input.MenuOrder)
            {
                Url = input.Url,
                UpperMenuId = input.UpperMenuId,
                IsActive = input.IsActive,
            };
        }
        public static Menu ToUpdateMenuInputEntity(this Menu menu, UpdateMenuInputDto input)
        {
            menu.SetTitle(input.Title);
            menu.SetMenuOrder(input.MenuOrder);
            menu.Url = input.Url;
            menu.UpperMenuId = input.UpperMenuId;
            menu.IsActive = input.IsActive;

            return menu;
        }

        public static MenuOutputDto ToMenuOutputDto(this Menu menu)
        {
            return new MenuOutputDto()
            {
                Id = menu.Id,
                Title = menu.Title,
                MenuOrder = menu.MenuOrder,
                Url = menu.Url,
                UpperMenuId = menu.UpperMenuId,
                IsActive = menu.IsActive
            };
        }
    }
}
