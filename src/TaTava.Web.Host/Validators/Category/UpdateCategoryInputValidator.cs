using System;
using TaTava.Categories.Dtos;
using TaTava.Extensions;

namespace TaTava.Web.Host.Validators.Category
{
    public class UpdateCategoryInputValidator : BaseDtoValidator<UpdateCategoryInputDto,Guid>
    {
        public UpdateCategoryInputValidator()
        {
            RuleFor(category => category.Title)
                .HasMaximumLength(100,"Kategori Başlık")
                .NullOrEmpty("Kategori Başık");
        }
    }
}