using System;
using TaTava.Extensions;
using TaTava.Menus.Dtos;

namespace TaTava.Web.Host.Validators.Menu
{
    public class UpdateMenuInputValidator : BaseDtoValidator<UpdateMenuInputDto,Guid>
    {
        public UpdateMenuInputValidator()
        {
             RuleFor(menu => menu.Title)
                .HasMaximumLength(100, "Başlık")
                .NullOrEmpty("Menü Başlık");
                
             RuleFor(menu => (menu.MenuOrder <= 0 ? 1:menu.MenuOrder).ToString())
              .HasMinimumLength(1, "Menü sırası")
              .NullOrEmpty("Menü Sırası");
        }
    }
}